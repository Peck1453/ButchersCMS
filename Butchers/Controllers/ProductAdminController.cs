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

        // Product/AddProduct
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

        // ProductAdmin/EditProduct/1
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

        // ProductAdmin/DeleteProduct/1
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {

            return View(_productService.GetProduct(id));

        }

        [HttpPost]
        public ActionResult DeleteProduct (Product product)
        {
            try
            {
                Product _product;
                _product = _productService.GetProduct(product.Id);
                _productService.DeleteProduct(_product);

            }

            catch
            {

            }
            return RedirectToAction("Products", new { controller = "Product" });
        }

        // ProductItemAdmin/AddProductItem
        [HttpGet]
        public ActionResult AddProductItem(string selectedProduct)
        {
            List<SelectListItem> productList = new List<SelectListItem>();
            foreach (var item in _productService.GetProducts())
            {
                productList.Add(
                    new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = (item.Name == (selectedProduct) ? true : false)
                    });
            }

            ViewBag.productList = productList;

            return View();
        }

        [HttpPost]
        public ActionResult AddProductItem(ProductItem productItem)
        {
            try
            {
                _productService.AddProductItem(productItem);
                return RedirectToAction("ProductItems", new { controller = "Product" });
            }
            catch
            {
                return View();
            }
        }

        // ProductItemAdmin/EditProductItem/1
        [HttpGet]
        public ActionResult EditProductItem(int id)
        {
            return View(_productService.GetProductItem(id));
        }

        [HttpPost]
        public ActionResult EditProductItem(int id, ProductItem productItem)
        {
            try
            {
                _productService.EditProductItem(productItem);
            }
            catch
            {

            }
            return RedirectToAction("ProductItems", new { controller = "Product" });
        }

        // ProductItemAdmin/DeleteProductItem/1
        [HttpGet]
        public ActionResult DeleteProductItem(int id)
        {
            return View(_productService.GetProductItem(id));
        }

        [HttpPost]
        public ActionResult DeleteProductItem(ProductItem productItem)
        {
            try
            {
                ProductItem _productItem;
                _productItem = _productService.GetProductItem(productItem.Id);
                _productService.DeleteProductItem(_productItem);
            }
            catch
            {

            }
            return RedirectToAction("ProductItems", new { controller = "Product" });
        }
    }
}