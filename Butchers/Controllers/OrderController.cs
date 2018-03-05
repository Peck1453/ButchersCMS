using Butchers.Data;
using Butchers.Data.BEANS;
using Butchers.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers
{
    public class OrderController : ApplicationController
    {

        public OrderController()
        {
            _orderService = new OrderService();
        }

        // Get Promo Codes
        public ActionResult PromoCode()
        {
            return View(_orderService.GetBEANPromoCodes());
        }

        // Get Cart Items
        public ActionResult CartItems()
        {
            return View(_orderService.GetBEANCartItems());
        }

        // Get Cart Items
        public ActionResult Orders()
        {
            return View(_orderService.GetBEANOrders());
        }
    }

}


