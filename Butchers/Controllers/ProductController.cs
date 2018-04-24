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
        public ActionResult Meats()     //Pulls the get method from the Product DAO and BEAN for Meats
        {
            return View(_productService.GetBEANMeats());
        }

        // GET: Products
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult Products()  //Pulls the get method from the Product DAO and BEAN for Products
        {
            return View(_productService.GetBEANProducts());
        }

        // GET: ProductItems
        [Authorize(Roles = "Manager, Staff, Customer")]
        public ActionResult ProductItems() //Pulls the product items that have not been discontinued if user is a customer- for manager and staff pulls all product Items
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
        public ActionResult ActiveProductItems() //Pulls all product items that have not been discontinued
        {
            return View(_productService.GetBEANProductItemsActive());
        }

        [Authorize(Roles = "Manager, Staff")]
        public ActionResult DiscontinuedProductItems()  //Pulls all product items that have been discontinued
        {
            return View(_productService.GetBEANDiscontinuedProductItems());
        }

        [Authorize(Roles = "Customer")] 
        public ActionResult _TopStock()  //Calls the top 4 products by highest quantity and display it on a partial view on the customer's dashboard
        {
            return PartialView(_productService.GetBEANProductItemsTopStock());
        }

        [Authorize(Roles = "Manager, Staff")]
        public ActionResult _LowStock() //Displays all product items where stock is below 5, and displays as partial view on dashboard of Manager and Staff
        {
            return PartialView(_productService.GetBEANProductItemsLowStock()); 
        }
        
        [Authorize(Roles = "Manager, Staff")]
        public ActionResult StockTransactions() //Displays all Staff/Manager Stock Trasactions that have taken place- from most to least recent
        {
            return View(_productService.GetBEANStockTransactions());
        }
    }
}