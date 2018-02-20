using Butchers.Data;
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
        public ActionResult AddPromoCode(PromoCode code)
        {

          
            try
            {
                _orderService.AddPromoCode(code);
                return RedirectToAction("PromoCode", new { cod = code.Code, controller = "Order" });
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
        public ActionResult EditPromoCode(string id, PromoCode code)
        {
            try
            {
                _orderService.EditPromoCode(code);
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
        public ActionResult DeletePromoCode(PromoCode code)
        {
            try
            {
                PromoCode _code;
                _code = _orderService.GetPromoDetail(code.Code);
                _orderService.DeletePromoCode(_code);
            }
            catch
            {

            }
            return RedirectToAction("PromoCode", new { controller = "Order" });
        }
    }
}


        

