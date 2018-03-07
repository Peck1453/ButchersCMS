using System;
using Butchers.Services.Service;
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

        public ActionResult Orders()
        {
            return View(_orderService.GetBEANOrders());
        }
    }
}


