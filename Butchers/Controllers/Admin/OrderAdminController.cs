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
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public ActionResult AddPromoCode(PromoCode pCode)
        {
            try
            {
                _orderService.AddPromoCode(pCode);
                return RedirectToAction("PromoCode", new { controller = "Order" });
            }
            catch
            {
                return View();
            }
        }

        // OrderAdmin/EditPromoCode/1
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public ActionResult EditPromoCode(string id)
        {
            return View(_orderService.GetBEANPromoCode(id));
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public ActionResult EditPromoCode(string id, PromoCodeBEAN codeBEAN)
        {
            try
            {
                PromoCode myPromoCode = new PromoCode
                {
                    Code = codeBEAN.Code,
                    Discount = codeBEAN.Discount,
                    ValidUntil = codeBEAN.ValidUntil
                };

                _orderService.EditPromoCode(myPromoCode);
            }
            catch
            {

            }
            return RedirectToAction("PromoCode", new { controller = "Order" });
        }

        
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public ActionResult DeleteCartItem(int id)
        {
            return View(_orderService.GetBEANCartItem(id));
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public ActionResult DeleteCartItem(int id, CartItemBEAN CartBEAN)
        {
            try
            {
                CartItem myCartItem = _orderService.GetCartItem(id);
                _orderService.DeleteCartItem(myCartItem);
            }
            catch
            {

            }
            return RedirectToAction("ProductItems", new { controller = "Product" });
        }

        // Add Product to the Cart
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
                    
                    cartId = _orderService.AddCartAndReturnId(cart);
        
                    Session["CartId"] = cartId;
                }
                else
                {
                    // If the Cart exists in Session, take the CartId and assign to the variable cartId
                    cartId = int.Parse(Session["CartId"].ToString());
                }

                CartItem cartItem = new CartItem
                {
                    CartId = cartId,
                    ProductItemId = productItemId,
                    Quantity = int.Parse(quantity),
                    ItemCostSubtotal = cost
                };

                _orderService.AddCartItem(cartItem);

                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex);
                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public ActionResult SubmitOrder(string promoCode, ProductItem item)
        {
            try
            {
                int cartId;

                // Assigns the session's CartId to the variable
                cartId = int.Parse(Session["CartId"].ToString());

                // Add an order
                Order order = new Order();

                var userID = User.Identity.GetUserId();
                if (!string.IsNullOrEmpty(userID))
                {
                    order.OrderDate = DateTime.Now; // Today's date
                    order.CustomerNo = userID; // Current Customer
                    order.TotalCost = _orderService.GetCartCost(cartId); // Uses the method which calculates Cart Cost
                    if (promoCode != null && promoCode != "")
                    {
                        decimal currentTotal = order.TotalCost;
                        order.PromoCode = promoCode; // Gets PromoCode from the form
                        order.TotalCostAfterDiscount = _orderService.GetCostAfterDiscount(currentTotal, promoCode); // Uses the method which applies the discount
                        if (order.TotalCostAfterDiscount == -1)
                        {
                            TempData["message"] = "The Promo code you entered is invalid.";
                            return RedirectToAction("ViewCart", new { controller = "Order" });
                        }
                    }
                    else
                    {
                        order.PromoCode = null; // Gets PromoCode from the form
                        order.TotalCostAfterDiscount = order.TotalCost; // Uses the method which applies the discount
                    }
                    order.CartId = cartId;


                    int orderNo = _orderService.AddOrderAndReturnId(order);

                    // Automatically set Order Details after the order has been placed.
                    OrderDetails orderDetails = new OrderDetails
                    {
                        OrderNo = orderNo,
                        CollectFrom = order.OrderDate.AddDays(1), // Pick up from Tomorrow
                        CollectBy = order.OrderDate.AddDays(8) // Order date + 8 days
                    };

                    _orderService.AddOrderDetails(orderDetails);

                    // Automatically reduce stock when an order is placed
                    IList<CartItemBEAN> items = _orderService.GetCartItemsByCartId(cartId);

                    foreach (var cartItem in items)
                    {
                        int id = cartItem.ProductItemId;

                        ProductItem myProductItem = _productService.GetProductItem(id);

                        myProductItem.StockQty = myProductItem.StockQty - cartItem.Quantity; // Calculates the new stock by taking reserved items from existing stock

                        _productService.EditProductItem(myProductItem);
                    }

                    // Clear the session
                    Session["CartId"] = null;

                    // Redirect to page to confirm the order
                    return RedirectToAction("CustomerOrders", new { controller = "Order" });
                } else {
                    return RedirectToAction("_LoginPartial", new { controller = "Shared" });
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Manager, Staff")]
        public ActionResult ToggleCollected(int id, OrderDetails orderDetails)
        {
            try
            {
                OrderDetails myOrderDetails = _orderService.ToggleCollected(id);

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
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
        }

    }
}


        

