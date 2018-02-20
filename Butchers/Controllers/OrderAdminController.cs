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
    }
}

        

