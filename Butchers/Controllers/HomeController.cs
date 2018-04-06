using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Butchers.Data;
using Butchers.Services.Service;

namespace Butchers.Controllers
{
    [Authorize(Roles = "Admin, Manager, Staff, Customer")]
    public class HomeController : Controller
    {
        public ProductService _productService;
        public OrderService _orderService;

        public HomeController()
        {
            _productService = new ProductService();
            _orderService = new OrderService();
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RegisterSuccess()
        {
            ViewBag.Message = "Registration Successful. Please log in.";

            return View();
        }

        public ActionResult Dashboard()
        {
            // Order Statistics
            ViewBag.CountPromoCodes = _orderService.CountPromoCodes();
            ViewBag.CountCarts = _orderService.CountCarts();
            ViewBag.CountOrders = _orderService.CountOrders();

            // Product Statistics
            ViewBag.CountMeats = _productService.CountMeats();
            ViewBag.CountProducts = _productService.CountProducts();
            ViewBag.CountProductItems = _productService.CountProductItems();

            return View();
        }
    }
}