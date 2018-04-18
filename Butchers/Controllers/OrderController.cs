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
    [Authorize(Roles = "Admin, Manager, Staff, Customer")]
    public class OrderController : ApplicationController
    {
        public OrderController()
        {
            
        }

        // PromoCodes
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult PromoCode()
        {
            return View(_orderService.GetBEANPromoCodes()); // returns a list of promo codes using the view model
        }

        // CartItems
        [Authorize(Roles = "Customer")]
        public ActionResult ViewCart()
        {

            int cartId;
            if (Session["CartId"] != null) // Checks to see whether a session exists for cart id
            {
                cartId = int.Parse(Session["CartId"].ToString()); // if it exists, assign the cartid to a variable
            }
            else
            {
                Cart cart = new Cart();
                
                cartId = _orderService.AddCartAndReturnId(cart); // If it doesn't exist, run AddCartAndReturnId and assign the new Id to CartId
                
                Session["CartId"] = cartId; // Assign the new variable cartId to the Session CartId
            }

            return View(_orderService.GetCartItemsByCartId(cartId)); // Returns a list of cart items where the id matches the cart
        }

        [Authorize(Roles = "Customer")]
        public ActionResult _SimpleCart() // This is used in the partial view for customers on the product items page
        {
            int cartId;
            if (Session["CartId"] != null) // Checks to see whether a session exists for cart id
            {
                cartId = int.Parse(Session["CartId"].ToString()); // if it exists, assign the cartid to a variable
            }
            else
            {
                Cart cart = new Cart();
                
                cartId = _orderService.AddCartAndReturnId(cart); // Run AddCartAndReturnId and assign the new Id to CartId
                
                Session["CartId"] = cartId; // Assign the new variable cartId to the Session CartId
            }

            return PartialView(_orderService.GetCartItemsByCartId(cartId)); // returns a list of cart items which match the session's cart id as a partial view 
        }

        // Orders
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult AllOrders()
        {
            return View(_orderService.GetBEANOrders());
        }

        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult CustomerOrders()
        {
            // Sets variable userId from the logged in user
            var userId = User.Identity.GetUserId();

            return View(_orderService.GetBEANCustomerOrders(userId));
        }

        // OrderDetails
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult OrderDetails(int id)
        {
            return View(_orderService.GetBEANOrder(id));
        }

        // OrderItems
        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult OrderItems(int cartId)
        {
            return View(_orderService.GetCartItemsByCartId(cartId));
        }
    }
}


