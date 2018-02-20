using Butchers.Data;
using Butchers.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers
{
    public class OrderAdminController : Controller
    {
        private Butchers.Services.IService.IOrderService _orderService;
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
    }
}


        

