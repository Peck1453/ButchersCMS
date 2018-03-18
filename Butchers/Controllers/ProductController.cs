using Butchers.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers
{
    [AllowAnonymous]
    public class ProductController : ApplicationController
    {
        public ProductController()
        {
            
        }

        // GET: Meats
        public ActionResult Meats()
        {
            return View(_productService.GetBEANMeats());
        }

        // GET: Products
        public ActionResult Products()
        {
            return View(_productService.GetBEANProducts());
        }

        // GET: ProductItems
        // Gets a list of all active / discontinued product items
        public ActionResult ProductItems()
        {
            return View(_productService.GetBEANProductItems());
        }

        // Gets a list of all active product items
        public ActionResult ActiveProductItems()
        {
            return View(_productService.GetBEANActiveProductItems());
        }

        // Gets a list of all discontinued product items
        public ActionResult DiscontinuedProductItems()
        {
            return View(_productService.GetBEANDiscontinuedProductItems());
        }
    }
}