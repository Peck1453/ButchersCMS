﻿using Butchers.Data;
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
            _orderService = new Butchers.Services.Service.OrderService();
        }
        public ActionResult PromoCode()
        {
            return View(_orderService.GetPromoCodes());
        }
        public ActionResult CartItems()
        {
            return View(_orderService.GetCartItems());
        }


        public ActionResult GetProductItem(int id)
        {

            return View(_orderService.GetProductItem(id));

        }


        public ActionResult AddCartItem ()
        {

            return View();

        }


        public ActionResult EditCartItem (int id )
        {

            return View(_orderService.GetProductItem(id));
        }


        public ActionResult DeleteCartItem()
        {

            return View();

        }


    }
}
