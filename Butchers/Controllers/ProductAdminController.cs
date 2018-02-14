using Butchers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers
{
    public class ProductAdminController : ApplicationController
    {
        public ProductAdminController()
        {

        }

        // Meat/AddMeat
        [HttpGet]
        public ActionResult AddMeat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMeat(Meat meat)
        {
            try
            {
                _productService.AddMeat(meat);
                return RedirectToAction("Meats", new { controller = "Product" });
            }
            catch
            {
                return View();
            }
        }

        // Meat/EditMeat/1
        [HttpGet]
        public ActionResult EditMeat(int id)
        {
            return View(_productService.GetMeat(id));
        }

        [HttpPost]
        public ActionResult EditMeat(int id, Meat meat)
        {
            try
            {
                _productService.EditMeat(meat);
            }
            catch
            {
                
            }
            return RedirectToAction("Meats", new { controller = "Product" });
        }
    }
}