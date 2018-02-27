using Butchers.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers
{
    public class ProductController : ApplicationController
    {
        public ProductController()
        {
            
        }

        // GET: Meats
        public ActionResult Meats()
        {
            return View(_productService.GetMeats());
        }

        // GET: Products
        public ActionResult Products()
        {
            return View(_productService.GetBEANProducts());
        }

        // GET: ProductItems
        public ActionResult ProductItems()
        {
            return View(_productService.GetProductItems());
        }
    }
}