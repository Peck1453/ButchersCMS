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

        // Meat/DeleteMeat/1
        [HttpGet]
        public ActionResult DeleteMeat(int id)
        {
            return View(_productService.GetMeat(id));
        }

        [HttpPost]
        public ActionResult DeleteMeat(Meat meat)
        {
            try
            {
                Meat _meat;
                _meat = _productService.GetMeat(meat.Id);
                _productService.DeleteMeat(_meat);
            }
            catch
            {

            }
            return RedirectToAction("Meats", new { controller = "Product" });
        }


        //product- add product

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            try
            {
                _productService.AddProduct(product);
                return RedirectToAction("Products", new { controller = "Product" });
            }
            catch
            {
                return View();
            }
        }

        //product- edit product

            [HttpGet]

        public ActionResult EditProduct(int id){

            return View(_productService.GetProduct(id));

        }

        [HttpPost]

        public ActionResult EditProduct(int id, Product product)
        {
            try
            {
                _productService.EditProduct(product);

            }
            catch
            {


            }
            return RedirectToAction("Products", new { controller = "Product" });


        }




        //product delete product

            [HttpGet]

        public ActionResult DeleteProduct(int id)
        {

            return View(_productService.GetProduct(id));

        }

        [HttpPost]

        public ActionResult DeleteProduct (int id, Product product)
        {
            try
            {
                _productService.DeleteProduct(product);

            }

            catch
            {
            }
                return RedirectToAction("Products", new { controller = "Product" });

        }
        
   


    }
}