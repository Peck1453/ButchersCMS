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

        // Get Promo Codes
        public ActionResult PromoCode()
        {
            return View(_orderService.GetBEANPromoCodes());
        }

        // Get Cart Items
        //public ActionResult CartItems()
        //{
        //    return View(_orderService.GetBEANCartItems());
        //}

        // Get Cart Items
        //public ActionResult Orders()
        //{
        //    return View(_orderService.GetBEANOrders());
        //}


        //public ActionResult AddCartItem()
        //{

        //    return View();

        //}
        //[HttpPost]
        //public ActionResult AddCartItem(CartItem cartItem)
        //{
        //    try
        //    {
        //        _orderService.AddCartItem(cartItem);
        //        return RedirectToAction("CartItems", new { controller = "Order" });
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //public ActionResult EditCartItem (int id )
        //{

        //    return View(_orderService.GetProductItem(id));
        //}


        //public ActionResult DeleteCartItem()
        //{

        //    return View();

        //}


    }

}


