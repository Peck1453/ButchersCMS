using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Butchers.Data;
using Butchers.Services.Service;

namespace Butchers.Controllers
{
    [AllowAnonymous]
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
            if (User.Identity.IsAuthenticated) // Checks whether the user is logged in or not
            {
                return RedirectToAction("Dashboard", "Home"); // If the user is logged in, redirect them to the dashboard instead of the index page
            }
            else
            {
                return View(); // If the user isn't logged in, redirect them to the index page as normal
            }
        }

        public ActionResult RegisterSuccess()
        {
            ViewBag.Message = "Registration Successful. Please log in."; // This is displayed after a user registers and is logged out

            return View();
        }

        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        public ActionResult Dashboard()
        {
            // Order Statistics - the results of these methods are assigned to viewbags and called upon in the razor views
            ViewBag.CountPromoCodes = _orderService.CountPromoCodes();
            ViewBag.CountCarts = _orderService.CountCarts();
            ViewBag.CountOrders = _orderService.CountOrders();
            ViewBag.countOrdersCollected = _orderService.countOrdersCollected();
            ViewBag.countOrdersCancelled = _orderService.countOrdersCancelled();

            // Product Statistics - the results of these methods are assigned to viewbags and called upon in the razor views
            ViewBag.CountMeats = _productService.CountMeats();
            ViewBag.CountProducts = _productService.CountProducts();
            ViewBag.CountProductItems = _productService.CountProductItems();

            return View();
        }
    }
}