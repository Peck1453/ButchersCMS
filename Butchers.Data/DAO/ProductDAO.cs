using Butchers.Data.BEANS;
using Butchers.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.DAO
{
    public class ProductDAO : IProductDAO
    {
        private ButchersEntities _context;

        public ProductDAO()
        {
            _context = new ButchersEntities();
        }

        // Meats
        public IList<Meat> GetMeats()  //Lists all available meats in database
        {
            IQueryable<Meat> _meats;

            _meats = from meat in _context.Meat
                     select meat;

            return _meats.ToList();
        }

        public int CountMeats()  //Counts total number of meats in Meats table and returns numerical value
        {
            IList<Meat> _meats = GetMeats();

            return _meats.Count();
        }

        public Meat GetMeat(int id) // gets specific meat where meat id = input
        {
            IQueryable<Meat> _meat;

            _meat = from meat
                    in _context.Meat
                    where meat.MeatId == id
                    select meat;

            return _meat.ToList().First();
        }
        
        public void AddMeat(Meat meat) // adds meat to Meat table
        {
            _context.Meat.Add(meat);
            _context.SaveChanges();
        }

        public void EditMeat(Meat meat) //edits details (name) of meat specified
        {
            Meat myMeat = GetMeat(meat.MeatId);

            myMeat.Name = meat.Name;
            _context.SaveChanges();
        }
        
         public void DeleteMeat(Meat meat) //removes meat to Meat table
         {		
             _context.Meat.Remove(meat);		
             _context.SaveChanges();		
         }

        // Meat BEANs
        public IList<MeatBEAN> GetBEANMeats() //Gets list of meats within a customised view with modified labels and text validation
        {
            IQueryable<MeatBEAN> _meatBEANs = from mt in _context.Meat
                                              select new MeatBEAN
                                              {
                                                  MeatId = mt.MeatId,
                                                  Name = mt.Name
                                              };
            return _meatBEANs.ToList();
        }

        public MeatBEAN GetBEANMeat(int id) //gets specific meat where meat id = input within customised BEAN view
        {
            {
                IQueryable<MeatBEAN> _meatBEANS = from mt in _context.Meat
                                                  where mt.MeatId == id
                                                  select new MeatBEAN
                                                  {
                                                      MeatId = mt.MeatId,
                                                      Name = mt.Name
                                                  };

                return _meatBEANS.ToList().First();
            }
        }

        // Meat APIs
        private bool MeatCheck(int id) //Checks if meat specified exists within the database, else produces "false" flag ulitmatelty leading to 404 message
        {
            IQueryable<int> meatList = from meats in _context.Meat
                                       select meats.MeatId;

            if (meatList.ToList().Contains(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Products
        public IList<Product> GetProducts() //Lists all available products in database
        {
            IQueryable<Product> _products = from prod in _context.Product
                                            select prod;

            return _products.ToList();
        }

        public int CountProducts() //Counts total number of products in Products table and returns numerical value
        {
            IList<Product> _products = GetProducts();

            return _products.Count();
        }

        public Product GetProduct(int id) // gets specific meat where meat id = input
        {
            IQueryable<Product> _product;

            _product = from product in _context.Product
                       where product.ProductId == id
                       select product;

            return _product.ToList().First();
        }

        public void AddProduct(Product product) // adds product to Meat table
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void EditProduct(Product product) //edits details (name, meatId) of product specified
        {
            Product _product = GetProduct(product.ProductId);

            _product.Name = product.Name;
            _product.MeatId = product.MeatId;

            _context.SaveChanges();
        }

        public void DeleteProduct(Product product) //removes product from Product table
        {
            Product myProduct = GetProduct(product.ProductId);

            _context.Product.Remove(product);
            _context.SaveChanges();
        }

        // Product BEANs
        public IList<ProductBEAN> GetBEANProducts() //Gets list of products within a customised view with modified labels and text validation
        {
            IQueryable<ProductBEAN> _productBEANs = from prod in _context.Product
                                                    from mt in _context.Meat
                                                    where prod.MeatId == mt.MeatId
                                                    select new ProductBEAN
                                                    {
                                                        ProductId = prod.ProductId,
                                                        Meat = mt.Name,
                                                        MeatId = mt.MeatId,
                                                        Name = prod.Name
                                                    };

            return _productBEANs.ToList();
        }

        public ProductBEAN GetBEANProduct(int id) //gets specific product where product id = input, within customised BEAN view
        {
            {
                IQueryable<ProductBEAN> _productBEANs = from prod in _context.Product
                                                        from mt in _context.Meat
                                                        where prod.ProductId == id
                                                        && prod.MeatId == mt.MeatId
                                                        select new ProductBEAN
                                                        {
                                                            ProductId = prod.ProductId,
                                                            Meat = mt.Name,
                                                            MeatId = mt.MeatId,
                                                            Name = prod.Name
                                                        };

                return _productBEANs.ToList().First();
            }
        }

        // Product APIs
        private bool ProductCheck(int id) //Checks if product specified exists within the database, else produces "false" flag ulitmatelty leading to 404 message
        {
            IQueryable<int> productList = from products in _context.Product
                                        select products.ProductId;
            if (productList.ToList().Contains(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Product Item
        public IList<ProductItem> GetProductItems() // Creates list of all productItems in ProductItems table
        {
            IQueryable<ProductItem> _productItems = from proditems in _context.ProductItem
                                                    select proditems;

            return _productItems.ToList();
        }

        public int CountProductItems() //Provides numerical manifestation of ProductItems currently in ProductItem table
        {
            IList<ProductItem> _productItems = GetProductItems();

            return _productItems.Count();
        }

        public ProductItem GetProductItem(int id) //Gets Specific Product Item based on Id
        {
            IQueryable<ProductItem> _productItem;

            _productItem = from productItem in _context.ProductItem
                           where productItem.ProductItemId == id
                           select productItem;

            return _productItem.ToList().First();
        }

        public void AddProductItem(ProductItem productItem) //Adds ProductItem to Database
        {
            _context.ProductItem.Add(productItem);
            _context.SaveChanges();
        }

        public void EditProductItem(ProductItem productItem) //Edits ProductItem by Cost Measurement, Discontinued status, ProductId or Stock Quantity
        {
            ProductItem myProductItem = GetProductItem(productItem.ProductItemId);

            myProductItem.Cost = productItem.Cost;
            myProductItem.MeasurementId = productItem.MeasurementId;
            myProductItem.Discontinued = productItem.Discontinued;
            myProductItem.ProductId = productItem.ProductId;
            myProductItem.StockQty = productItem.StockQty;

            _context.SaveChanges();
        }

        public void ToggleProductItem(ProductItem productItem, string user) // This method toggles the Enable/Disabled function of a productItem. 
        {
            ProductItem myProductItem = GetProductItem(productItem.ProductItemId);

            if (myProductItem.Discontinued == true) // If discontinued
            {
                myProductItem.Discontinued = false; // Change to active
            }
            else
            {
                StockTransaction stockTransaction = new StockTransaction()  //In addition to toggling the status, this method removes all current stock on the item being discontinued and logs it in the stock transaction table
                {
                    ProductItemId = myProductItem.ProductItemId,
                    AddedBy = user,
                    CurrentStock = myProductItem.StockQty,
                    QtyToAdd = -myProductItem.StockQty,
                    DateAdded = DateTime.Now
                };

                AddStockTransaction(stockTransaction);

                myProductItem.Discontinued = true;
                myProductItem.StockQty = 0;
            }
            EditProductItem(myProductItem);
            _context.SaveChanges();
        }

        // ProductItem BEANs
        public IList<ProductItemBEAN> GetBEANProductItems() //Creates list of productItems within customised view where Meat Id shows as Meat Name for ease of comprehension
        {
            IQueryable<ProductItemBEAN> _productItemBEANs = from proditems in _context.ProductItem
                                                            from prod in _context.Product
                                                            from measure in _context.Measurement
                                                            where proditems.ProductId == prod.ProductId
                                                            && proditems.MeasurementId == measure.MeasurementId
                                                            orderby proditems.StockQty descending
                                                            select new ProductItemBEAN
                                                            {
                                                                ProductItemId = proditems.ProductItemId,
                                                                Product = prod.Name,
                                                                Cost = proditems.Cost,
                                                                MeasurementId = proditems.MeasurementId,
                                                                MeasurementName = measure.MeasurementName,
                                                                Discontinued = proditems.Discontinued,
                                                                ProductId = prod.ProductId,
                                                                StockQty = proditems.StockQty
                                                            };

            return _productItemBEANs.ToList();
        }

        public IList<ProductItemBEAN> GetBEANProductItemsTopStock() // Creates a list of product items and displays the top 4 when listed by quantity in descending order 
        {
            IQueryable<ProductItemBEAN> _productItemBEANs = (from proditems in _context.ProductItem
                                                             from prod in _context.Product
                                                             from measure in _context.Measurement
                                                             where proditems.ProductId == prod.ProductId
                                                             && proditems.MeasurementId == measure.MeasurementId
                                                             orderby proditems.StockQty descending
                                                             select new ProductItemBEAN
                                                             {
                                                                 ProductItemId = proditems.ProductItemId,
                                                                 Product = prod.Name,
                                                                 Cost = proditems.Cost,
                                                                 MeasurementId = proditems.MeasurementId,
                                                                 MeasurementName = measure.MeasurementName,
                                                                 Discontinued = proditems.Discontinued,
                                                                 ProductId = prod.ProductId,
                                                                 StockQty = proditems.StockQty
                                                             }).Take(4);

            return _productItemBEANs.ToList();
        }

        public IList<ProductItemBEAN> GetBEANProductItemsLowStock() //Creates list of products in customised view where stock quantity is less than 5, then sorts from lowest stock upwards
        {
            IQueryable<ProductItemBEAN> _productItemBEANs = from proditems in _context.ProductItem
                                                             from prod in _context.Product
                                                             from measure in _context.Measurement
                                                             where proditems.ProductId == prod.ProductId
                                                             && proditems.MeasurementId == measure.MeasurementId
                                                             && proditems.StockQty < 5
                                                             && proditems.Discontinued == false
                                                             orderby proditems.StockQty ascending
                                                             select new ProductItemBEAN
                                                             {
                                                                 ProductItemId = proditems.ProductItemId,
                                                                 Product = prod.Name,
                                                                 Cost = proditems.Cost,
                                                                 MeasurementId = proditems.MeasurementId,
                                                                 MeasurementName = measure.MeasurementName,
                                                                 Discontinued = proditems.Discontinued,
                                                                 ProductId = prod.ProductId,
                                                                 StockQty = proditems.StockQty
                                                             };

            return _productItemBEANs.ToList();
        }

        public IList<ProductItemBEAN> GetBEANProductItemsActive()      // Only shows product items that haven't been discontinued
        {
            IQueryable<ProductItemBEAN> _productItemBEANs = from proditems in _context.ProductItem
                                                            from prod in _context.Product
                                                            from measure in _context.Measurement
                                                            where proditems.Discontinued == false
                                                            && proditems.ProductId == prod.ProductId
                                                            && proditems.MeasurementId == measure.MeasurementId
                                                            orderby proditems.StockQty descending
                                                            select new ProductItemBEAN
                                                            {
                                                                ProductItemId = proditems.ProductItemId,
                                                                Product = prod.Name,
                                                                Cost = proditems.Cost,
                                                                MeasurementName = measure.MeasurementName,
                                                                Discontinued = proditems.Discontinued,
                                                                ProductId = prod.ProductId,
                                                                StockQty = proditems.StockQty
                                                            };

            return _productItemBEANs.ToList();
        }
        
        public IList<ProductItemBEAN> GetBEANDiscontinuedProductItems() // Only shows product items that have been discontinued
        {
            IQueryable<ProductItemBEAN> _productItemBEANs = from proditems in _context.ProductItem
                                                            from prod in _context.Product
                                                            from measure in _context.Measurement
                                                            where proditems.Discontinued == true
                                                            && proditems.ProductId == prod.ProductId
                                                            && proditems.MeasurementId == measure.MeasurementId
                                                            select new ProductItemBEAN
                                                            {
                                                                ProductItemId = proditems.ProductItemId,
                                                                Product = prod.Name,
                                                                Cost = proditems.Cost,
                                                                MeasurementName = measure.MeasurementName,
                                                                Discontinued = proditems.Discontinued,
                                                                ProductId = prod.ProductId,
                                                                StockQty = proditems.StockQty
                                                            };

            return _productItemBEANs.ToList();
        }

        public ProductItemBEAN GetBEANProductItem(int id) //Gets specific ProductItem based on Id and displays it in customised view 
        {
            IQueryable<ProductItemBEAN> _productItemBEAN = from proditems in _context.ProductItem
                                                           from prod in _context.Product
                                                           from measure in _context.Measurement
                                                           where proditems.ProductItemId == id
                                                           && proditems.ProductId == prod.ProductId
                                                            && proditems.MeasurementId == measure.MeasurementId
                                                           select new ProductItemBEAN
                                                           {
                                                               ProductItemId = proditems.ProductItemId,
                                                               Product = prod.Name,
                                                               Cost = proditems.Cost,
                                                               MeasurementId = proditems.MeasurementId,
                                                               MeasurementName = measure.MeasurementName,
                                                               Discontinued = proditems.Discontinued,
                                                               ProductId = prod.ProductId,
                                                               StockQty = proditems.StockQty
                                                           };

            return _productItemBEAN.ToList().First();
        }

        // ProductItem APIs
        private bool ProductItemCheck(int id)  //Checks if productItem specified exists within the database, else produces "false" flag ultimatelty leading to 404 message
        {
            IQueryable<int> productItemList = from productitem in _context.ProductItem
                                              select productitem.ProductItemId;

            if (productItemList.ToList().Contains(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool EditAPIProductItem(ProductItem productItem) // doesn't use the BEAN as this is not necessary for the edit
        {
            if (ProductItemCheck(productItem.ProductItemId) == true)
            {
                ProductItem myProductItem = GetProductItem(productItem.ProductItemId); // this doesn't use the BEAN because it is't not needed for updating stock qty

                myProductItem.ProductId = productItem.ProductId;
                myProductItem.Cost = productItem.Cost;
                myProductItem.MeasurementId = productItem.MeasurementId;
                myProductItem.Discontinued = productItem.Discontinued;
                myProductItem.StockQty = productItem.StockQty;

                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        // Measurement
        public IList<Measurement> GetMeasurements() //Lists all available measurements in database
        {
            IQueryable<Measurement> _measurements = from measurements in _context.Measurement
                                                    select measurements;

            return _measurements.ToList();
        }

        public Measurement GetMeasurement(int id) // gets specific measurement where meat id = input
        {
            IQueryable<Measurement> _measurement;

            _measurement = from measurement in _context.Measurement
                           where measurement.MeasurementId == id
                           select measurement;

            return _measurement.ToList().First();
        }

        public void AddMeasurement(Measurement measurement) // adds measurements to Measurement table
        {
            _context.Measurement.Add(measurement);
            _context.SaveChanges();
        }

        public void EditMeasurement(Measurement measurement) //edits details (name, amount) of measurement specified
        {
            Measurement myMeasurement = GetMeasurement(measurement.MeasurementId);

            myMeasurement.MeasurementName = measurement.MeasurementName;
            myMeasurement.GramsPerMeasurement = measurement.GramsPerMeasurement;

            _context.SaveChanges();
        }

        public void DeleteMeasurement(Measurement measurement) //removes meat to Meat table
        {
            _context.Measurement.Remove(measurement);
            _context.SaveChanges();
        }

        // ProductItem BEANs
        public IList<MeasurementBEAN> GetBEANMeasurements() //Gets list of measurement within a customised view with modified labels and text validation
        {
            IQueryable<MeasurementBEAN> _measurementBEANs = from measurements in _context.Measurement
                                                            select new MeasurementBEAN
                                                            {
                                                                MeasurementId = measurements.MeasurementId,
                                                                MeasurementName = measurements.MeasurementName,
                                                                GramsPerMeasurement = measurements.GramsPerMeasurement
                                                            };

            return _measurementBEANs.ToList();
        }

        public MeasurementBEAN GetBEANMeasurement(int id) //gets specific measurement where measurement id = input, within customised BEAN view
        {
            IQueryable<MeasurementBEAN> _measurementBEAN = from measurements in _context.Measurement
                                                           where measurements.MeasurementId == id
                                                           select new MeasurementBEAN
                                                           {
                                                               MeasurementId = measurements.MeasurementId,
                                                               MeasurementName = measurements.MeasurementName,
                                                               GramsPerMeasurement = measurements.GramsPerMeasurement
                                                           };

            return _measurementBEAN.ToList().First();
        }
        
        private bool MeasurementCheck(int id)
        {
            IQueryable<int> measurementList = from measurement in _context.Measurement
                                              select measurement.MeasurementId;

            if (measurementList.ToList().Contains(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Stock Transaction
        public IList<StockTransaction> GetStockTransactions() //Lists all available stock Transactions in database and arranges it most recent first
        {
            IQueryable<StockTransaction> _stocktransactions;

            _stocktransactions = from stocktransaction in _context.StockTransaction
                                 orderby stocktransaction.TransactionId descending
                                 select stocktransaction;

            return _stocktransactions.ToList();
        }

        public StockTransaction GetStockTransaction(int id) // gets specific stock Transaction where transaction id = input
        {
            IQueryable<StockTransaction> _stocktransaction;

            _stocktransaction = from stocktransaction
                                in _context.StockTransaction
                                where stocktransaction.TransactionId == id
                                select stocktransaction;

            return _stocktransaction.ToList().First();
        }

        public void AddStockTransaction(StockTransaction stockTransaction) // adds stock Transaction to Stock Transaction table
        {
            _context.StockTransaction.Add(stockTransaction);
            _context.SaveChanges();
        }

        //Stock Transaction BEANs
        public IList<StockTransactionBEAN> GetBEANStockTransactions()  //Gets list of stock transaction within a customised view with modified labels and text validation
        {
            IQueryable<StockTransactionBEAN> _stocktransactionBEANs = from stock in _context.StockTransaction
                                                                      from proditem in _context.ProductItem
                                                                      from prod in _context.Product
                                                                      where stock.ProductItemId == proditem.ProductItemId
                                                                      where proditem.ProductId == prod.ProductId
                                                                      orderby stock.TransactionId descending
                                                                      select new StockTransactionBEAN
                                                                      {
                                                                          TransactionId = stock.TransactionId,
                                                                          ProductItemId = stock.ProductItemId,
                                                                          ProductName = prod.Name,
                                                                          AddedBy = stock.AddedBy,
                                                                          currentStock = stock.CurrentStock,
                                                                          QtyToAdd = stock.QtyToAdd,
                                                                          UpdatedTotal = (stock.CurrentStock + stock.QtyToAdd),
                                                                          DateAdded = stock.DateAdded
                                                                      };
            return _stocktransactionBEANs.ToList();
        }

        public StockTransactionBEAN GetBEANStockTransaction(int id) //gets specific stock Transaction where transaction id = input, within a customised BEAN view
        {

            IQueryable<StockTransactionBEAN> _stocktransactionBEANs = from stock in _context.StockTransaction
                                                                      from proditem in _context.ProductItem
                                                                      from prod in _context.Product
                                                                      where stock.TransactionId == id
                                                                      && stock.ProductItemId == proditem.ProductItemId
                                                                      where proditem.ProductId == prod.ProductId
                                                                      select new StockTransactionBEAN
                                                                      {
                                                                          TransactionId = stock.TransactionId,
                                                                          ProductItemId = stock.ProductItemId,
                                                                          ProductName = prod.Name,
                                                                          AddedBy = stock.AddedBy,
                                                                          currentStock = stock.CurrentStock,
                                                                          QtyToAdd = stock.QtyToAdd,
                                                                          UpdatedTotal = (stock.CurrentStock + stock.QtyToAdd),
                                                                          DateAdded = stock.DateAdded
                                                                      };
            return _stocktransactionBEANs.ToList().First();
        }

        //Stock Transaction API
        public bool AddAPIStockTransaction(StockTransaction stockTransaction) // Adds Stock Transaction so outside enties that consume our code are logged and aufited as well
        {
            {
                try
                {
                    _context.StockTransaction.Add(stockTransaction);
                    _context.SaveChanges();
                    return true;
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{ 0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                    return false;
                    throw;
                }
            }


        }

    }
}
