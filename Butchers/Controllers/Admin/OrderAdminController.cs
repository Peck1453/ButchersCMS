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
    [Authorize(Roles = "Admin, Manager, Customer")]
    public class OrderAdminController : ApplicationController
    {
        public OrderAdminController()
        {

        }

        // OrderAdmin/AddPromoCode
        [HttpGet]
        public ActionResult AddPromoCode()
        {
            return View();
        }

        [HttpPost]
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
        public ActionResult EditPromoCode(string id)
        {
            return View(_orderService.GetBEANPromoCode(id));
        }

        [HttpPost]

        public ActionResult EditPromoCode(string id, PromoCodeBEAN codeBEAN)
        {
            try
            {
                PromoCode myPromoCode = new PromoCode();

                myPromoCode.Code = codeBEAN.Code;
                myPromoCode.Discount = codeBEAN.Discount;
                myPromoCode.ValidUntil = codeBEAN.ValidUntil;

                _orderService.EditPromoCode(myPromoCode);
            }
            catch
            {

            }
            return RedirectToAction("PromoCode", new { controller = "Order" });
        }

        // OrderAdmin/DeletePromoCode/1
        [HttpGet]
        public ActionResult DeletePromoCode(string id)
        {
            return View(_orderService.GetBEANPromoCode(id));
        }

        [HttpPost]
        public ActionResult DeletePromoCode(string id, PromoCodeBEAN codeBEAN)
        {
            try
            {
                PromoCode myPromoCode = _orderService.GetPromoCode(id);
                _orderService.DeletePromoCode(myPromoCode);
            }
            catch
            {

            }
            return RedirectToAction("PromoCode", new { controller = "Order" });
        }

        // OrderAdmin/AddCartItem
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult AddCartItem(string selectedProductItem)
        {
            List<SelectListItem> itemList = new List<SelectListItem>();
            foreach (var item in _productService.GetBEANProductItems())
            {
                itemList.Add(
                    new SelectListItem()
                    {
                        Text = item.Product,
                        Value = item.ProductItemId.ToString(),
                        Selected = (item.Product == (selectedProductItem) ? true : false)
                    });
            }
            ViewBag.itemList = itemList;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult AddCartItem(CartItem cartItem)

        {
            try
            {
                _orderService.AddCartItem(cartItem);
                return RedirectToAction("CartItems", new { controller = "Order" });
            }
            catch
            {
                return View();
            }
        }

        // OrderAdmin/EditCartItem/1
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult EditCartItem(int id, int product)
        {
            List<SelectListItem> itemList = new List<SelectListItem>();
            foreach (var item in _productService.GetBEANProductItems())
            {
                itemList.Add(
                  new SelectListItem()
                  {
                      Text = item.Product,
                      Value = item.ProductItemId.ToString(),
                      Selected = (item.ProductItemId == (product) ? true : false)
                  });
            }
            ViewBag.itemList = itemList;
            return View(_orderService.GetBEANCartItem(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult EditCartItem(int id, CartItemBEAN cartBEAN)
        {
            try
            {
                CartItem myCartItem = new CartItem();

                myCartItem.CartItemId = cartBEAN.CartItemId;
                myCartItem.ProductItemId = cartBEAN.ProductItemId;
                myCartItem.CartId = cartBEAN.CartId;
                myCartItem.Quantity = cartBEAN.Quantity;
                myCartItem.ItemCostSubtotal = cartBEAN.ItemCostSubtotal;

                _orderService.EditCartItem(myCartItem);
            }
            catch
            {

            }
            return RedirectToAction("CartItems", new { Controller = "Order" });
        }

        // OrderAdmin/DeleteCartItem/1
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult DeleteCartItem(int id)
        {
            return View(_orderService.GetBEANCartItem(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
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
            return RedirectToAction("CartItems", new { Controller = "Order" });
        }

        // OrderAdmin/AddCart
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult AddCart(string selectedProductItem)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult AddCart(Cart cart)
        {
            try
            {
                _orderService.AddCart(cart);
                return RedirectToAction("Carts", new { controller = "Order" });
            }
            catch
            {
                return View();
            }
        }

        // Select a Quantity for ProductItem before adding to Cart
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult SelectCartItemQuantity(int id)
        {
            return View(_productService.GetBEANProductItem(id));
        }

        // Add Product to the Cart
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
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

                CartItem cartItem = new CartItem();

                cartItem.CartId = cartId;
                cartItem.ProductItemId = productItemId;
                cartItem.Quantity = int.Parse(quantity);
                cartItem.ItemCostSubtotal = cost;

                _orderService.AddCartItem(cartItem);

                return RedirectToAction("ViewCart", new { controller = "Order" });
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex);
                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
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
                    }
                    else
                    {
                        order.PromoCode = null; // Gets PromoCode from the form
                        order.TotalCostAfterDiscount = order.TotalCost; // Uses the method which applies the discount
                    }
                    order.CartId = cartId;
                }
                
                int orderNo = _orderService.AddOrderAndReturnId(order); 

                // Automatically set Order Details after the order has been placed.
                OrderDetails orderDetails = new OrderDetails();

                orderDetails.OrderNo = orderNo;
                orderDetails.CollectFrom = order.OrderDate.AddDays(1); // Pick up from Tomorrow
                orderDetails.CollectBy = order.OrderDate.AddDays(8); // Order date + 8 days

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
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex);
                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
        }

        // OrderAdmin/EditCart/1
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult EditCart(int id)
        {
            return View(_orderService.GetBEANCart(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult EditCart(int id, CartBEAN cartBEAN)
        {
            try
            {
                Cart myCart = new Cart();

                myCart.CartId = cartBEAN.CartId;

                _orderService.EditCart(myCart);
            }
            catch
            {

            }
            return RedirectToAction("Carts", new { Controller = "Order" });
        }

        // OrderAdmin/DeleteCart/1
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult DeleteCart(int id)
        {
            return View(_orderService.GetBEANCart(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult DeleteCart(int id, CartBEAN CartBEAN)
        {
            try
            {
                Cart myCart = _orderService.GetCart(id);
                _orderService.DeleteCart(myCart);
            }
            catch
            {

            }
            return RedirectToAction("Carts", new { Controller = "Order" });
        }
        
        // OrderAdmin/AddOrder
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult AddOrder(string selectedPromoCode)
        {
            List<SelectListItem> codeList = new List<SelectListItem>();
            foreach (var item in _orderService.GetPromoCodes())
            {
                codeList.Add(
                    new SelectListItem()
                    {
                        Text = item.Discount.ToString() + "%",
                        Value = item.Code.ToString(),
                        Selected = (item.Discount.ToString() == (selectedPromoCode) ? true : false)
                    });
            }
            ViewBag.codeList = codeList;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult AddOrder(Order order)
        {
            try
            {
                _orderService.AddOrder(order);
                return RedirectToAction("Orders", new { controller = "Order" });
            }
            catch
            {
                return View();
            }
        }

        // OrderAdmin/EditOrder/1
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult EditOrder(int id)
        {
            return View(_orderService.GetBEANOrder(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult EditOrder(int id, OrderBEAN orderBEAN)
        {
            try
            {
                Order myOrder = new Order();

                myOrder.OrderNo = orderBEAN.OrderNo;
                myOrder.OrderDate = orderBEAN.OrderDate;
                myOrder.CustomerNo = orderBEAN.CustomerNo;
                myOrder.PromoCode = orderBEAN.PromoCode;
                myOrder.TotalCost = orderBEAN.TotalCost;
                myOrder.CartId = orderBEAN.CartId;
                myOrder.TotalCostAfterDiscount = orderBEAN.TotalCostAfterDiscount;

                _orderService.EditOrder(myOrder);
            }
            catch
            {

            }
            return RedirectToAction("Orders", new { Controller = "Order" });
        }

        // OrderAdmin/DeleteOrder/1
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult DeleteOrder(int id)
        {
            return View(_orderService.GetBEANOrder(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult DeleteOrder(int id, OrderBEAN orderBEAN)
        {
            try
            {
                Order myOrder = _orderService.GetOrder(id);
                _orderService.DeleteOrder(myOrder);
            }
            catch
            {

            }
            return RedirectToAction("Orders", new { Controller = "Order" });
        }

        // OrderAdmin/AddOrderDetails
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult AddOrderDetails(string selectedOrder)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult AddOrderDetails(OrderDetails details)
        {
            try
            {
                _orderService.AddOrderDetails(details);
                return RedirectToAction("OrderDetails", new { controller = "Order" });
            }
            catch
            {
                return View();
            }
        }

        // OrderAdmin/EditOrderDetails/1
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult EditOrderDetails(int id)
        {
            return View(_orderService.GetBEANOrderDetail(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult EditOrderDetails(int id, OrderDetailsBEAN detailsBEAN)
        {
            try
            {
                OrderDetails myOrderDetails = new OrderDetails();

                myOrderDetails.OrderDetailsId = detailsBEAN.OrderDetailsId;
                myOrderDetails.OrderNo = detailsBEAN.OrderNo;
                myOrderDetails.CollectFrom = detailsBEAN.CollectFrom;
                myOrderDetails.CollectBy = detailsBEAN.CollectBy;
                myOrderDetails.Collected = detailsBEAN.Collected;

                _orderService.EditOrderDetails(myOrderDetails);
            }
            catch
            {

            }
            return RedirectToAction("OrderDetails", new { controller = "Order" });
        }

        // OrderAdmin/DeletePromoCode/1
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult DeleteOrderDetails(int id)
        {
            return View(_orderService.GetBEANOrderDetail(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult DeleteOrderDetails(int id, OrderDetailsBEAN detailsBEAN)
        {
            try
            {
                OrderDetails myOrderDetails = _orderService.GetOrderDetail(id);
                _orderService.DeleteOrderDetails(myOrderDetails);
            }
            catch
            {

            }
            return RedirectToAction("OrderDetails", new { controller = "Order" });
        }
    }
}


        

