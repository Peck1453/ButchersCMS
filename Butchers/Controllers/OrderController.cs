using Butchers.Data;
using Butchers.Data.BEANS;
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

        // Get Promo Codes
        public ActionResult PromoCode()
        {
            return View(_orderService.GetPromoCodes());
        }

        // Get Cart Items
        public ActionResult CartItems()
        {
            return View(_orderService.GetCartItems());
        }

        // Get Cart Items
        public ActionResult Orders()
        {
            return View(_orderService.GetBEANOrders());
        }

        // These need moving to admin
        public ActionResult GetProductItem(int id)
        {

            return View(_orderService.GetProductItem(id));

        }

        [HttpGet]
        public ActionResult AddCartItem()
        {

            return View();

        }

        [HttpPost]
        public ActionResult AddCartItem(CartItem  Citem)

        {
            try
            {

                _orderService.AddCartItem(Citem);
                return RedirectToAction("CartItems", new { controller = "Order" });


            }

            catch

            {

                return View();

            }


        }

        //Edit Admin cart Items
        [HttpGet]
        public ActionResult EditCartItem(int id)
        {

            return View(_orderService.GetCartItemBEAN(id));
        }

        [HttpPost]
        public ActionResult EditCartItem(int id, CartItemBEAN CartBEAN )
        {   
            try
            {
                CartItem myCartItem = new CartItem();

                myCartItem.Id = CartBEAN.Id;
                myCartItem.ProductItem = CartBEAN.ProductItem;
                myCartItem.Quantity = CartBEAN.Quantity;
                myCartItem.DateAdded = CartBEAN.DateAdded;


                _orderService.EditCartItem(myCartItem);

            }
            catch
            {

            }

            return RedirectToAction("CartItems", new { Controller = "Order" });




        }
        //Delete admin duties 
        [HttpGet]
        public ActionResult DeleteCartItem(int id)
        {

            return View(_orderService.GetCartItemBEAN(id));

        }

        [HttpPost]

        public ActionResult DeleteCartItem(int id, CartItemBEAN CartBEAN)
        {

            try
            {
                CartItem myCartItem = _orderService.GetProductItem(id);
                _orderService.DeleteCartItem(myCartItem);

            }
            catch
            {


            }

                return RedirectToAction("CartItems", new { Controller = "Order" });
                     




        }
    }

}


