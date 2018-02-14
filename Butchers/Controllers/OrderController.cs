using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers
{
    public class OrderController : Controller
    {
        private Butchers.Services.IService.IOrderService _orderService;
        public OrderController()
        {
            _orderService = new Butchers.Services.Service.OrderService();
        }
        public ActionResult PromoCode()
        {
            return View(_orderService.GetPromoCodes());
        }
    }
}
