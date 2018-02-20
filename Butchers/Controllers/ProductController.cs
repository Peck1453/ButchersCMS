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

        // No view yet
        // GET: Meat
        public ActionResult Meat(int id)
        {
            return View(_productService.GetMeat(id));
        }

        public ActionResult Products()
        {

            return View(_productService.GetProducts());

        }

        public ActionResult Product(int id)
        {

            return View(_productService.GetProduct(id));
        }
    }
}