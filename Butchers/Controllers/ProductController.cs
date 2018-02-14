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
            //_productService = new ProductService();
        }

        // GET: Meat
        public ActionResult Meats()
        {
            return View(_productService.GetMeats());
        }
    }
}