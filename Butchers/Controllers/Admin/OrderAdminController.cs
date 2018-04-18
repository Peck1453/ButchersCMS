using Butchers.Data;
using Butchers.Data.BEANS;
using Butchers.Services.IService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers.Admin
{
    [Authorize(Roles = "Admin, Manager, Staff, Customer")]
    public class OrderAdminController : ApplicationController
    {
        public OrderAdminController()
        {

        }

        // OrderAdmin/AddPromoCode
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public ActionResult AddPromoCode()
        {
            // Returns the addPromoCode view
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public ActionResult AddPromoCode(PromoCode pCode)
        {
            try
            {
                // Adds the promo code
                _orderService.AddPromoCode(pCode);

                // Returns the user to the promo code list
                return RedirectToAction("PromoCode", new { controller = "Order" });
            }
            catch
            {
                // This currently redirects the user to the addPromoCode view
                // ** This would benefit from some error recognition by using an error page or toaster notifications
                return View();
            }
        }

        // OrderAdmin/EditPromoCode/1
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public ActionResult EditPromoCode(string id)
        {
            // The edit promocode view is returned matching the id (code) of the selected promo code
            return View(_orderService.GetBEANPromoCode(id));
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public ActionResult EditPromoCode(string id, PromoCodeBEAN codeBEAN)
        {
            try
            {
                // The promo code object is updated...
                PromoCode myPromoCode = new PromoCode
                {
                    Code = codeBEAN.Code,
                    Discount = codeBEAN.Discount,
                    ValidUntil = codeBEAN.ValidUntil
                };

                // ...and the edit method is called upon, updating the existing values with the new ones
                _orderService.EditPromoCode(myPromoCode);
            }
            catch
            {

            }

            // Whether a success or failure, the user is redirected back to the promo code list
            // ** This can be refined with error notifications
            return RedirectToAction("PromoCode", new { controller = "Order" });
        }


        // Cart items are the product items which have been added to the cart
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public ActionResult DeleteCartItem(int id)
        {
            // The delete cart item view is returned to the user matching the item selected for deletion
            return View(_orderService.GetBEANCartItem(id));
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public ActionResult DeleteCartItem(int id, CartItemBEAN CartBEAN)
        {
            try
            {
                // The cart item is selected from the id of the list item which has been chosen
                CartItem myCartItem = _orderService.GetCartItem(id);

                // The delete method is called upon passing the object for deletion
                _orderService.DeleteCartItem(myCartItem);
            }
            catch
            {

            }

            // Pass or fail, the user is redirected back to the product item list
            // ** This could do with some error notification
            return RedirectToAction("ProductItems", new { controller = "Product" });
        }

        // This replaced AddCartItem as more functionality was needed
        // This takes care of adding product items to a cart
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public ActionResult AddProductToCart(int productItemId, decimal cost, string quantity)
        {
            try
            {
                int cartId;

                // Check to see whether Cart exists
                if (Session["CartId"] == null)
                {
                    Cart cart = new Cart();

                    // If the cart doesn't exist, one is created and the AddCartAndReturnId method does what it says
                    cartId = _orderService.AddCartAndReturnId(cart);
        
                    // We use that id to assign the variable to the session
                    Session["CartId"] = cartId;
                }
                else
                {
                    // If the Cart exists in Session, take the CartId and assign to the variable cartId
                    cartId = int.Parse(Session["CartId"].ToString());
                }

                // From the productItem selected, quantity entered and the session, a cartItem is created
                CartItem cartItem = new CartItem
                {
                    CartId = cartId,
                    ProductItemId = productItemId,
                    Quantity = int.Parse(quantity),
                    ItemCostSubtotal = cost
                };

                // This information is passed to the AddCartItem method to add a new cart item
                _orderService.AddCartItem(cartItem);

                // Once these steps have been executed, the user is redirected
                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex);

                // ** This would benefit from better error notification
                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
        }

        // SubmitOrder takes the cartItems and a number of other variables and adds them to a customer order
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public ActionResult SubmitOrder(string promoCode, ProductItem item)
        {
            try
            {
                int cartId;

                // Assigns the session's CartId to the variable
                // We assume that one exists otherwise they wouldn't see the options for Submitting an order
                cartId = int.Parse(Session["CartId"].ToString());

                // Add an order
                Order order = new Order();

                // This detects the logged in user's id and assigns it to the variable userId
                var userID = User.Identity.GetUserId();

                // As long as there is a user logged in, the order can be processed, otherwise they are redirected to log in
                // An unauthenticated user shouldn't be able to get to this point anyway, it's just a failsafe
                if (!string.IsNullOrEmpty(userID))
                {
                    order.OrderDate = DateTime.Now; // Today's date
                    order.CustomerNo = userID; // Current Customer
                    order.TotalCost = _orderService.GetCartCost(cartId); // Uses the method which calculates Cart Cost

                    // This checks to see whether a promo code is being used
                    if (promoCode != null && promoCode != "")
                    {
                        // Assigns the current total cost and promo code to variables that can be used by the GetCostAfterDiscount method
                        decimal currentTotal = order.TotalCost;
                        order.PromoCode = promoCode; 

                        // Uses the method which applies the discount
                        order.TotalCostAfterDiscount = _orderService.GetCostAfterDiscount(currentTotal, promoCode); 
                        
                        
                        // This is currently used to notify the user that the promo code is invalid
                        if (order.TotalCostAfterDiscount == -1) // -1 is returned if the promo code is invalid
                        {
                            TempData["message"] = "The Promo code you entered is invalid.";

                            // ** This probably needs improving with a more standardised way of giving feedback to the user (toaster, etc)
                            return RedirectToAction("ViewCart", new { controller = "Order" });
                        }
                    }
                    else
                    {
                        order.PromoCode = null; // If there is no promo code entered, don't use one
                        order.TotalCostAfterDiscount = order.TotalCost; // If no promo code, there will be no discount
                    }
                    order.CartId = cartId;

                    // Using the information above, add an order and return its id (order no) to generate the order details
                    int orderNo = _orderService.AddOrderAndReturnId(order);

                    // Automatically set Order Details after the order has been placed.
                    OrderDetails orderDetails = new OrderDetails
                    {
                        OrderNo = orderNo, // Use the order number generated from the add method
                        CollectFrom = order.OrderDate.AddDays(1), // Take tomorrow's date
                        CollectBy = order.OrderDate.AddDays(8) // Take tomorrow's date + 8 days

                        // ** The days for collection could be customised by business preferences when this is implemented
                    };

                    _orderService.AddOrderDetails(orderDetails);

                    // Automatically reduce stock when an order is placed by looping through a list of the items in the cart
                    IList<CartItemBEAN> items = _orderService.GetCartItemsByCartId(cartId);
                    foreach (var cartItem in items)
                    {
                        int id = cartItem.ProductItemId;

                        // Identify the cart item by Id and get the ProductItem details
                        ProductItem myProductItem = _productService.GetProductItem(id);

                        // Calculates the new stock by taking reserved items from existing stock
                        myProductItem.StockQty = myProductItem.StockQty - cartItem.Quantity; 

                        // The item is edited and the loop continues for every item in the GetCartItemsByCartId method
                        _productService.EditProductItem(myProductItem);
                    }

                    // Clear the session as this is no longer needed.
                    Session["CartId"] = null;

                    // Redirect to page to confirm the order
                    return RedirectToAction("CustomerOrders", new { controller = "Order" });
                }
                else
                {
                    return RedirectToAction("_LoginPartial", new { controller = "Shared" });
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
        }

        // Used to toggle between collected and not collected for customer orders
        [HttpGet]
        [Authorize(Roles = "Manager, Staff")]
        public ActionResult ToggleCollected(int id, OrderDetails orderDetails)
        {
            try
            {
                // The id of the order (order no) is passed to identify the order details which are being updated
                OrderDetails myOrderDetails = _orderService.ToggleCollected(id);

                // Find the status and change to the opposite.
                // ** I think this can be refined
                if (myOrderDetails.Collected == true)
                {
                    myOrderDetails.Collected = false;
                    _orderService.EditOrderDetails(myOrderDetails);
                }
                else
                {
                    myOrderDetails.Collected = true;
                    _orderService.EditOrderDetails(myOrderDetails);
                }

                // Redirect to the previous page
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);

                // ** Some error notification here would be better
                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
        }

    }
}


        

