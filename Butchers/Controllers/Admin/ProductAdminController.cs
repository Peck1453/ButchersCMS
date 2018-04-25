using Butchers.Data;
using Butchers.Data.BEANS;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers.Admin
{
    [Authorize(Roles = "Admin, Manager, Staff, Customer")]
    public class ProductAdminController : ApplicationController
    {
        public ProductAdminController()
        {

        }

        // ProductAdmin/AddMeat
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddMeat() // Generates a blank add form as no values are passed
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddMeat(Meat meat) //Pulls the method, from the Product DAO, for adding meat 
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

        // ProductAdmin/EditMeat/1
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditMeat(int id)  //Pulls the method for displaying all Meat
        {
            return View(_productService.GetBEANMeat(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditMeat(int id, MeatBEAN meatBEAN) //Pulls the method, from the Product DAO, for editing meat 
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

        // ProductAdmin/DeleteMeat/1
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteMeat(int id)  //Pulls the method for displaying all Meat
        {
            return View(_productService.GetBEANMeat(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteMeat(int id, MeatBEAN meatBEAN)  //Pulls the method, from the Product DAO, for editing meat
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

        // ProductAdmin/AddProduct
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddProduct(string selectedMeat)  //Pulls the method, from the DAO, for displaying Products
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
        [Authorize(Roles = "Admin")]
        public ActionResult AddProduct(Product product) //Pulls the method for adding the requested Product
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
        [Authorize(Roles = "Admin")]
        public ActionResult EditProduct(int id, int meatId)  //Collects the product data to be edited
        {
            List<SelectListItem> meatList = new List<SelectListItem>();
            foreach (var item in _productService.GetMeats())
            {
                meatList.Add(
                  new SelectListItem()                                  //Pulls the Meats from the database and compliles them into a ViewBag to be placed on the Edit Page
                  {
                      Text = item.Name,
                      Value = item.MeatId.ToString(),
                      Selected = (item.MeatId == (meatId) ? true : false)
                  });
            }
            ViewBag.meatList = meatList;
            return View(_productService.GetBEANProduct(id)); //Pulls the method, from the DAO for creating a list of products from the database
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditProduct(int id, ProductBEAN productBEAN) //Edits a product in the Product Table
        {
            try
            {
                Product myProduct = new Product
                {
                    ProductId = productBEAN.ProductId, //Collects Data to be edited from the BEAN
                    MeatId = productBEAN.MeatId,
                    Name = productBEAN.Name
                };

                _productService.EditProduct(myProduct); //Pulls the Method for Editing Products from the DAO
            }
            catch
            {

            }
            return RedirectToAction("Products", new { controller = "Product" });
        }

        // ProductAdmin/DeleteProduct/1
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int id) //Pulls the method for displaying the requested Product
        {
            return View(_productService.GetBEANProduct(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct (int id, ProductBEAN productBEAN) //Deletes the requested Product (identified by the Product ID)
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

        // ProductAdmin/AddProductItem
        [HttpGet]
        [Authorize(Roles = "Manager, Staff")]
        public ActionResult AddProductItem(string selectedProduct, string selectedMeasurement)  //Adds a productItem to the ProductItem Table
        {
            List<SelectListItem> productList = new List<SelectListItem>();
            foreach (var item in _productService.GetProducts())
            {
                productList.Add( //Creates a list of available products in the products table
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
                measurementList.Add(        //Creates a list of available measurements in the measurements table
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
        [Authorize(Roles = "Manager, Staff")]
        public ActionResult AddProductItem(ProductItem productItem) //Calls the Add Product Item Method from the DAO
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

        // ProductAdmin/EditProductItem/1
        [HttpGet]
        [Authorize(Roles = "Manager, Staff")]
        public ActionResult EditProductItem(int id, int product, int measurement)  //Collects the product data to be edited
        {
            List<SelectListItem> productList = new List<SelectListItem>();
            foreach (var item in _productService.GetProducts())
            {
                productList.Add(
                    new SelectListItem() //Creates a list of available products in the products table
                    {
                        Text = item.Name,
                        Value = item.ProductId.ToString(),
                        Selected = (item.ProductId == (product) ? true : false)
                    });
            }

            List<SelectListItem> measurementList = new List<SelectListItem>();
            foreach (var item in _productService.GetMeasurements())
            {
                measurementList.Add( //Creates a list of available measurements in the measurements table

                    new SelectListItem()
                    {
                        Text = item.MeasurementName,
                        Value = item.MeasurementId.ToString(),
                        Selected = (item.MeasurementId == (measurement) ? true : false)
                    });
            }

            ViewBag.productList = productList;
            ViewBag.measurementList = measurementList;

            return View(_productService.GetBEANProductItem(id)); //Calls the method from the DAO to call the specific product item to be edited
        }

        [HttpPost]
        [Authorize(Roles = "Manager, Staff")]
        public ActionResult EditProductItem(int id, ProductItem productItem) //Edits a productItem in the ProductItem Table
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


        // Toggle Product Item
        [HttpGet]
        [Authorize(Roles = "Manager, Staff")]
        public ActionResult ToggleProductItem(int id, ProductItem productItem) // Calls the menthod that toggles products enabled/disabled status
        {
            try
            {
                ProductItem myProductItem = _productService.GetProductItem(id);

                string user = User.Identity.GetUserName(); // This detects the logged in user's id and assigns it to the variable userId

                _productService.ToggleProductItem(myProductItem, user);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }


        // Add Stock
        [HttpGet]
        [Authorize(Roles = "Manager, Staff")]
        public ActionResult UpdateStock(int productItemId, int stockQty, string quantity, ProductItem item) //The method that changed the stock amount when managers/staff add stock
        {
            try
            {
                ProductItem myProductItem = _productService.GetProductItem(productItemId);  //gets method in DAO for accessing product Item details
                var user = User.Identity.Name;//Itentifies the current user

                if (myProductItem.Discontinued == true)
                {
                    _productService.ToggleProductItem(myProductItem, user); // sets the prodcut as enabled, if it has been disabled
                }

                myProductItem.StockQty = (stockQty + int.Parse(quantity)); //adds to ProductItem Table- StockQuantity field the amount selected on the dropdown list

                    _productService.EditProductItem(myProductItem); //Calls the Edit Product Item method from the DAO
                
                StockTransaction stockTransaction = new StockTransaction() //takes details on the product, user, stock amaount, stock, change and the current date...
                {
                    ProductItemId = productItemId, 
                    AddedBy = user,
                    CurrentStock = stockQty,
                    QtyToAdd = int.Parse(quantity),
                    DateAdded = DateTime.Now,
                };
                _productService.AddStockTransaction(stockTransaction);//and adds them to the table "stockTransactions" in the Model- this created a log for auditing purpose
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
            
            return Redirect(Request.UrlReferrer.ToString());
        }

        // Remove Stock
        public ActionResult TakeStock(int productItemId, int stockQty, string quantity, ProductItem item)// Performs almost the same as the above method, but where the previous method added stock, this one takes away
        {
            try
            {
                ProductItem myProductItem = _productService.GetProductItem(productItemId);

                myProductItem.StockQty = (stockQty - int.Parse(quantity));

                _productService.EditProductItem(myProductItem);

                var user = User.Identity.Name;
                StockTransaction stockTransaction = new StockTransaction() //And logs who has taken stock away and when
                {
                    ProductItemId = productItemId,
                    AddedBy = user,
                    CurrentStock = stockQty,
                    QtyToAdd = -int.Parse(quantity),
                    DateAdded = DateTime.Now,
                };
                _productService.AddStockTransaction(stockTransaction);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}