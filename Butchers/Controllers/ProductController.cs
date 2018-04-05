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
            if (User.IsInRole("Customer"))
            {
                return RedirectToAction("ActiveProductItems", "Product");
            }
            else if (User.IsInRole("Manager") || User.IsInRole("Staff"))
            {
                return View(_productService.GetBEANProductItems());
            }
            else
            {
                return View(_productService.GetBEANProductItems());
            }
        }

        // Gets a list of all active product items
        public ActionResult ActiveProductItems()
        {
            return View(_productService.GetBEANProductItemsActive());
        }

        // Gets a list of all discontinued product items
        public ActionResult DiscontinuedProductItems()
        {
            return View(_productService.GetBEANDiscontinuedProductItems());
        }
        
        public ActionResult _TopStock()
        {
            return PartialView(_productService.GetBEANProductItemsTopStock());
        }
        
        public ActionResult _LowStock()
        {
            return PartialView(_productService.GetBEANProductItemsLowStock());
        }

        //GET Stock Transactions

        public ActionResult StockTransactions()
        {
            return View(_productService.GetBEANStockTransactions());
        }
    }
}