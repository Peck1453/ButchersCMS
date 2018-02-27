﻿using Butchers.Data;
using Butchers.Data.BEANS;
using Butchers.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers
{
    public class OrderAdminController : ApplicationController
    {
        public OrderAdminController()
        {

        }

        // OrderAdmin/AddPromoCode/1
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
            return View(_orderService.GetPromoCodeBEAN(id));
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
            return View(_orderService.GetPromoCodeBEAN(id));
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

        // OrderAdmin/AddOrder
        [HttpGet]
        public ActionResult AddOrder(string selectedPromoCode)
        {
            List<SelectListItem> codeList = new List<SelectListItem>();
            foreach (var item in _orderService.GetPromoCodes())
            {
                codeList.Add(
                    new SelectListItem()
                    {
                        Text = item.Discount.ToString() + "%",
                        Value = item.Code.ToString(),
                        Selected = (item.Discount.ToString() == (selectedPromoCode) ? true : false)
                    });
            }
            ViewBag.codeList = codeList;
            return View();
        }

        [HttpPost]
        public ActionResult AddOrder(Order order)
        {
            try
            {
                _orderService.AddOrder(order);
                return RedirectToAction("Orders", new { controller = "Order" });
            }
            catch
            {
                return View();
            }
        }

        // OrderAdmin/EditPromoCode/1
        [HttpGet]
        public ActionResult EditOrder(int id)
        {
            return View(_orderService.GetBEANOrder(id));
        }

        [HttpPost]
        public ActionResult EditOrder(int id, OrderBEAN orderBEAN)
        {
            try
            {
                Order _order = new Order();
                
                _order.OrderDate = orderBEAN.OrderDate;
                _order.CollectFrom = orderBEAN.CollectFrom;
                _order.CollectBy = orderBEAN.CollectBy;
                _order.Customer = orderBEAN.Customer;
                _order.Collected = orderBEAN.Collected;
                _order.PromoCode = orderBEAN.PromoCode;
                _order.TotalCost = orderBEAN.TotalCost;

                _orderService.EditOrder(_order);
            }
            catch
            {

            }
            return RedirectToAction("Orders", new { controller = "Order" });
        }

        // OrderAdmin/DeletePromoCode/1
        [HttpGet]
        public ActionResult DeleteOrder(int id)
        {
            return View(_orderService.GetBEANOrder(id));
        }

        [HttpPost]
        public ActionResult DeleteOrder(int id, OrderBEAN orderBEAN)
        {
            try
            {
                Order _order = _orderService.GetOrder(id);
                _orderService.DeleteOrder(_order);
            }
            catch
            {

            }
            return RedirectToAction("Orders", new { controller = "Order" });
        }
    }
}


        

