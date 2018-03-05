﻿using System;
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


        public ActionResult GetProductItem(int id)
        {

            return View(_orderService.GetProductItem(id));

        }


        public ActionResult AddCartItem()
        {

            return View();

        }
        [HttpPost]
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


        [HttpPost]
        public ActionResult AddProductItem(ProductItem productItem)
        {
            try
            {
                _productService.AddProductItem(productItem);
                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
            catch
            {
                return View();
            }
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


