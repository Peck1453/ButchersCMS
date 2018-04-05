﻿using Butchers.Data;
using Butchers.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers.Admin
{
    [Authorize(Roles = "Admin, Manager, Customer")]
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
            return View(_productService.GetBEANMeat(id));
        }

        [HttpPost]
        public ActionResult EditMeat(int id, MeatBEAN meatBEAN)
        {
            try
            {
                Meat myMeat = new Meat
                {
                    MeatId = meatBEAN.MeatId,
                    Name = meatBEAN.Name
                };

                _productService.EditMeat(myMeat);
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
            return View(_productService.GetBEANMeat(id));
        }

        [HttpPost]
        public ActionResult DeleteMeat(int id, MeatBEAN meatBEAN)
        {
            try
            {
                
                Meat myMeat = _productService.GetMeat(id);
                _productService.DeleteMeat(myMeat);
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
                      Value = item.MeatId.ToString(),
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
        public ActionResult EditProduct(int id, int meatId)
        {
            List<SelectListItem> meatList = new List<SelectListItem>();
            foreach (var item in _productService.GetMeats())
            {
                meatList.Add(
                  new SelectListItem()
                  {
                      Text = item.Name,
                      Value = item.MeatId.ToString(),
                      Selected = (item.MeatId == (meatId) ? true : false)
                  });
            }
            ViewBag.meatList = meatList;
            return View(_productService.GetBEANProduct(id));
        }

        [HttpPost]
        public ActionResult EditProduct(int id, ProductBEAN productBEAN)
        {
            try
            {
                Product myProduct = new Product
                {
                    ProductId = productBEAN.ProductId,
                    MeatId = productBEAN.MeatId,
                    Name = productBEAN.Name
                };

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
            return View(_productService.GetBEANProduct(id));
        }

        [HttpPost]
        public ActionResult DeleteProduct (int id, ProductBEAN productBEAN)
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
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult AddProductItem(string selectedProduct, string selectedMeasurement)
        {
            List<SelectListItem> productList = new List<SelectListItem>();
            foreach (var item in _productService.GetProducts())
            {
                productList.Add(
                    new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.ProductId.ToString(),
                        Selected = (item.Name == (selectedProduct) ? true : false)
                    });
            }

            List<SelectListItem> measurementList = new List<SelectListItem>();
            foreach (var item in _productService.GetMeasurements())
            {
                measurementList.Add(
                    new SelectListItem()
                    {
                        Text = item.MeasurementName,
                        Value = item.MeasurementId.ToString(),
                        Selected = (item.MeasurementName == (selectedMeasurement) ? true : false)
                    });
            }

            ViewBag.productList = productList;
            ViewBag.measurementList = measurementList;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff")]
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
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult EditProductItem(int id, int product, int measurement)
        {
            List<SelectListItem> productList = new List<SelectListItem>();
            foreach (var item in _productService.GetProducts())
            {
                productList.Add(
                    new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.ProductId.ToString(),
                        Selected = (item.ProductId == (product) ? true : false)
                    });
            }

            List<SelectListItem> measurementList = new List<SelectListItem>();
            foreach (var item in _productService.GetMeasurements())
            {
                measurementList.Add(
                    new SelectListItem()
                    {
                        Text = item.MeasurementName,
                        Value = item.MeasurementId.ToString(),
                        Selected = (item.MeasurementId == (measurement) ? true : false)
                    });
            }

            ViewBag.productList = productList;
            ViewBag.measurementList = measurementList;

            return View(_productService.GetBEANProductItem(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff")]
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

        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult ToggleProductItem(int id, ProductItem productItem)
        {
            try
            {
                ProductItem myProductItem = _productService.GetProductItem(id);
                _productService.ToggleProductItem(myProductItem);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        // ProductItemAdmin/DeleteProductItem/1
        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult DeleteProductItem(int id)
        {
            return View(_productService.GetBEANProductItem(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult DeleteProductItem(int id, ProductItem productItem)
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

        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Staff")]
        public ActionResult UpdateStock(int productItemId, int stockQty, string quantity, ProductItem item)
        {
            try
            {
                    ProductItem myProductItem = _productService.GetProductItem(productItemId);

                if (myProductItem.Discontinued == true)
                {
                    _productService.ToggleProductItem(myProductItem);
                }

                myProductItem.StockQty = (stockQty + int.Parse(quantity));

                    _productService.EditProductItem(myProductItem);

                // Change to Stock Transaction Stuff
                var user = User.Identity.Name;
                StockTransaction stockTransaction = new StockTransaction()
                {
                    //CartId = cartId;
                    //Quantity = int.Parse(quantity);
                    //ItemCostSubtotal = cost;

                    //You might need to pass in some parameters here (see cart item)
                    ProductItemId = productItemId,
                    AddedBy = user,
                    CurrentStock = stockQty,
                    QtyToAdd = int.Parse(quantity),
                    DateAdded = DateTime.Now,
                };
                _productService.AddStockTransaction(stockTransaction);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
            }

            //this needs the redirect thing I found and put in deletecartitem (get latest)
            return Redirect(Request.UrlReferrer.ToString());
        }

        //Add StockTransaction
        [HttpGet]
        public ActionResult AddStockTransaction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStockTransaction(StockTransaction stockTransaction)
        {
            _productService.AddStockTransaction(stockTransaction);
            return RedirectToAction("StockTransactions", new { controller = "Product" });


        }


    }
}