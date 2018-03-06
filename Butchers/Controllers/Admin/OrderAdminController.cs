﻿using Butchers.Data;
using Butchers.Data.BEANS;
using Butchers.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers.Admin
{
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
        public ActionResult DeleteCartItem(int id)
        {
            return View(_orderService.GetBEANCartItem(id));
        }

        //[HttpPost]

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
        public ActionResult AddCart(string selectedProductItem)
        {
            return View();
        }

        [HttpPost]
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

        // OrderAdmin/EditCart/1
        [HttpGet]
        public ActionResult EditCart(int id)
        {
            return View(_orderService.GetBEANCart(id));
        }

        [HttpPost]
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
        public ActionResult DeleteCart(int id)
        {
            return View(_orderService.GetBEANCart(id));
        }

        //[HttpPost]

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

        //// OrderAdmin/AddOrder
        //[HttpGet]
        //public ActionResult AddOrder(string selectedPromoCode)
        //{
        //    List<SelectListItem> codeList = new List<SelectListItem>();
        //    foreach (var item in _orderService.GetPromoCodes())
        //    {
        //        codeList.Add(
        //            new SelectListItem()
        //            {
        //                Text = item.Discount.ToString() + "%",
        //                Value = item.Code.ToString(),
        //                Selected = (item.Discount.ToString() == (selectedPromoCode) ? true : false)
        //            });
        //    }
        //    ViewBag.codeList = codeList;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddOrder(Order order)
        //{
        //    try
        //    {
        //        _orderService.AddOrder(order);
        //        return RedirectToAction("Orders", new { controller = "Order" });
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// OrderAdmin/EditPromoCode/1
        //[HttpGet]
        //public ActionResult EditOrder(int id)
        //{
        //    return View(_orderService.GetBEANOrder(id));
        //}

        //[HttpPost]
        //public ActionResult EditOrder(int id, OrderBEAN orderBEAN)
        //{
        //    try
        //    {
        //        Order _order = new Order();

        //        _order.OrderDate = orderBEAN.OrderDate;
        //        _order.CustomerNo = orderBEAN.Customer;
        //        _order.PromoCode = orderBEAN.PromoCode;
        //        _order.TotalCost = orderBEAN.TotalCost;

        //        _orderService.EditOrder(_order);
        //    }
        //    catch
        //    {

        //    }
        //    return RedirectToAction("Orders", new { controller = "Order" });
        //}

        //// OrderAdmin/DeletePromoCode/1
        //[HttpGet]
        //public ActionResult DeleteOrder(int id)
        //{
        //    return View(_orderService.GetBEANOrder(id));
        //}

        //[HttpPost]
        //public ActionResult DeleteOrder(int id, OrderBEAN orderBEAN)
        //{
        //    try
        //    {
        //        Order _order = _orderService.GetOrder(id);
        //        _orderService.DeleteOrder(_order);
        //    }
        //    catch
        //    {

        //    }
        //    return RedirectToAction("Orders", new { controller = "Order" });
        //}

        // OrderAdmin/AddOrderDetails
        [HttpGet]
        public ActionResult AddOrderDetails(string selectedOrder)
        {
            //List<SelectListItem> orderList = new List<SelectListItem>();
            //foreach (var item in _orderService.GetOrders())
            //{
            //    orderList.Add(
            //      new SelectListItem()
            //      {
            //          Text = item.OrderNo,
            //          Value = item.OrderNo.ToString(),
            //          Selected = (item.OrderNo == (selectedOrder) ? true : false)
            //      });
            //}
            //ViewBag.orderList = orderList;
            return View();
        }

        [HttpPost]
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
        public ActionResult EditOrderDetails(int id)
        {
            //List<SelectListItem> orderList = new List<SelectListItem>();
            //foreach (var item in _orderService.GetOrders())
            //{
            //    orderList.Add(
            //      new SelectListItem()
            //      {
            //          Text = item.OrderNo,
            //          Value = item.OrderNo.ToString(),
            //          Selected = (item.OrderNo == (order) ? true : false)
            //      });
            //}
            //ViewBag.orderList = orderList;
            return View(_orderService.GetBEANOrderDetail(id));
        }

        [HttpPost]
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
        public ActionResult DeleteOrderDetails(int id)
        {
            return View(_orderService.GetBEANOrderDetail(id));
        }

        [HttpPost]
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


        

