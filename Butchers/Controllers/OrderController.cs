using System;
using Butchers.Services.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        // Carts
        public ActionResult Carts()
        {
            return View(_orderService.GetBEANCarts());
        }

        // Orders
        //public ActionResult Orders()
        //{
        //    return View(_orderService.GetBEANOrders());
        //}

        // OrderDetails
        public ActionResult OrderDetails()
        {
            return View(_orderService.GetBEANOrderDetails());
        }
    }
}


