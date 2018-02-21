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
        // PromoCode/AddPromoCode/1
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
        public ActionResult DeletePromoCode(string id,PromoCode pCode)
        {
            try
            {

                
               pCode = _orderService.GetPromoDetail(id);
               _orderService.DeletePromoCode(pCode);

            }

            catch
            {

            }
            return RedirectToAction("PromoCode", new { controller = "Order" });
        }

        
    }
}


        

