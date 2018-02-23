using Butchers.Data;
using Butchers.Data.BEANS;
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
        public ActionResult AddProduct(string selectedMeat)
        {
            List<SelectListItem> meatList = new List<SelectListItem>();
            foreach(var item in _productService.GetMeats())
            {
                meatList.Add(
                  new SelectListItem()
                  {
                      Text = item.Name,
                      Value = item.Id.ToString(),
                      Selected = (item.Name == (selectedMeat) ? true : false)
                  });
            }
            ViewBag.meatList = meatList;
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
        public ActionResult EditProduct(int id, ProductBEAN product)
        {
            try
            {
                Product myProduct = new Product();

                myProduct.Id = product.Id;
                myProduct.MeatId = product.MeatId;
                myProduct.Name = product.Name;




                _productService.EditProduct(myProduct);

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
        public ActionResult DeleteProduct (int id, ProductBEAN product)
        {
            try
            {
                Product myProduct = _productService.GetProduct(id);

                _productService.DeleteProduct(myProduct);
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
            return View(_productService.GetProductItemBEAN(id));
        }

        [HttpPost]
        public ActionResult EditProductItem(int id, ProductItemBEAN productItem)
        {
            try
            {
                ProductItem myProductItem = new ProductItem();

                myProductItem.Id = productItem.Id;
                myProductItem.ProductId = productItem.ProductId;
                myProductItem.Cost = productItem.Cost;
                myProductItem.PerUnit = productItem.PerUnit;
                myProductItem.Discontinued = productItem.Discontinued;

                _productService.EditProductItem(myProductItem);
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
            return View(_productService.GetProductItemBEAN(id));
        }

        [HttpPost]
        public ActionResult DeleteProductItem(int id, ProductItemBEAN productItem)
        {
            try
            {
                ProductItem myProductItem = _productService.GetProductItem(id);
                _productService.DeleteProductItem(myProductItem);
            }
            catch
            {

            }
            return RedirectToAction("ProductItems", new { controller = "Product" });
        }
    }
}