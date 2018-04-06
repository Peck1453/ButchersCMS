using Butchers.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers
{
    [Authorize(Roles = "Admin, Manager, Staff, Customer")]
    public class ProductController : ApplicationController
    {
        public ProductController()
        {
            
        }

        // GET: Meats
        [Authorize(Roles = "Admin")]
        public ActionResult Meats()
        {
            return View(_productService.GetBEANMeats());
        }

        // GET: Products
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult Products()
        {
            return View(_productService.GetBEANProducts());
        }

        // GET: ProductItems
        [Authorize(Roles = "Manager, Staff, Customer")]
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
        
        [Authorize(Roles = "Manager, Staff, Customer")]
        public ActionResult ActiveProductItems()
        {
            return View(_productService.GetBEANProductItemsActive());
        }

        [Authorize(Roles = "Manager, Staff")]
        public ActionResult DiscontinuedProductItems()
        {
            return View(_productService.GetBEANDiscontinuedProductItems());
        }

        [Authorize(Roles = "Customer")]
        public ActionResult _TopStock()
        {
            return PartialView(_productService.GetBEANProductItemsTopStock());
        }

        [Authorize(Roles = "Manager, Staff")]
        public ActionResult _LowStock()
        {
            return PartialView(_productService.GetBEANProductItemsLowStock());
        }


        [Authorize(Roles = "Manager, Staff")]
        public ActionResult StockTransactions()
        {
            return View(_productService.GetBEANStockTransactions());
        }
    }
}