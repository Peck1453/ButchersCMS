using System;
using Butchers.Services.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Butchers.Data;
using Microsoft.AspNet.Identity;

namespace Butchers.Controllers
{
    [AllowAnonymous]
    public class OrderController : ApplicationController
    {

        public OrderController()
        {
            
        }

        // PromoCodes
        public ActionResult PromoCode()
        {
            return View(_orderService.GetBEANPromoCodes());
        }

        // CartItems
        public ActionResult CartItems()
        {
            return View(_orderService.GetBEANCartItems());
        }

        public ActionResult ViewCart()
        {

            int cartId;
            if (Session["CartId"] != null)
            {
                cartId = int.Parse(Session["CartId"].ToString());
            } else
            {
                Cart cart = new Cart();

                // Run AddCartAndReturnId and assign the new Id to CartId
                cartId = _orderService.AddCartAndReturnId(cart);

                // Assign the new variable cartId to the Session CartId
                Session["CartId"] = cartId;
            }
            

            return View(_orderService.GetCartItemsByCartId(cartId));
        }

        // Carts
        public ActionResult Carts()
        {
            return View(_orderService.GetBEANCarts());
        }

        // Orders
        public ActionResult Orders()
        {
            return View(_orderService.GetBEANOrders());
        }

        // Orders
        public ActionResult CustomerOrders()
        {
            // Sets variable userId from the logged in user
            var userId = User.Identity.GetUserId();

            return View(_orderService.GetBEANCustomerOrders(userId));
        }

        // OrderDetails
        public ActionResult OrderDetails()
        {
            return View(_orderService.GetBEANOrderDetails());
        }
    }
}


