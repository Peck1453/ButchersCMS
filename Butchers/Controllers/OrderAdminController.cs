﻿using Butchers.Data;
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
        [HttpGet] // PromoCode/AddPromoCode/1
        public ActionResult AddPromoCode()
        {
            
            return View();
        }

        [HttpPost] // PromoCode/AddPromoCode/1
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
        // Meat/EditPromoCode/1
        [HttpGet]
        public ActionResult EditPromoCode(string id)
        {
            return View(_orderService.GetPromoDetail(id));
        }

        [HttpPost]
        public ActionResult EditPromoCode(string id, PromoCode pCode)
        {
            try
            {
                _orderService.EditPromoCode(pCode);
                

            }
            catch
            {
                
            }
            return RedirectToAction("PromoCode", new { controller = "Order" });
        }
        // Meat/DeletePromoCode/1
        [HttpGet]
        public ActionResult DeletePromoCode(string id)
        {
            return View(_orderService.GetPromoDetail(id));
        }

        [HttpPost]
        public ActionResult DeletePromoCode(PromoCode pCode)
        {
            try
            {
                PromoCode _code;
                _code = _orderService.GetPromoDetail(pCode.Code);
                _orderService.DeletePromoCode(_code);
                
            }
            catch
            {
               
            }
            return RedirectToAction("PromoCode", new { controller = "Order" });
        }
    }
}


        

