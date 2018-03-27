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
        public IList<Meat> GetMeats()
        {
            IQueryable<Meat> _meats;

            _meats = from meat in _context.Meat
                     select meat;

            return _meats.ToList();
        }

        public Meat GetMeat(int id)
        {
            IQueryable<Meat> _meat;

            _meat = from meat
                    in _context.Meat
                    where meat.MeatId == id
                    select meat;

            return _meat.ToList().First();
        }



        public void AddMeat(Meat meat)
        {
            _context.Meat.Add(meat);
            _context.SaveChanges();
        }

        public void EditMeat(Meat meat)
        {
            Meat myMeat = GetMeat(meat.MeatId);

            myMeat.Name = meat.Name;
            _context.SaveChanges();
        }
        
         public void DeleteMeat(Meat meat)
         {		
             _context.Meat.Remove(meat);		
             _context.SaveChanges();		
         }

        // Meat BEANs
        public IList<MeatBEAN> GetBEANMeats()
        {
            IQueryable<MeatBEAN> _meatBEANs = from mt in _context.Meat
                                              select new MeatBEAN
                                              {
                                                  MeatId = mt.MeatId,
                                                  Name = mt.Name
                                              };

            return _meatBEANs.ToList();
        }

        public MeatBEAN GetBEANMeat(int id)
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
        private bool MeatCheck(int id)
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

        public bool AddAPIMeat(Meat meat)
        {
            try
            {
                _context.Meat.Add(meat);
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

        public bool EditAPIMeat(Meat meat)
        {
            if (MeatCheck(meat.MeatId) == true)
            {
                Meat myMeat = GetMeat(meat.MeatId);

                myMeat.Name = meat.Name;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAPIMeat(Meat meat)
        {
            if (MeatCheck(meat.MeatId) == true)
            {
                _context.Meat.Remove(meat);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        // Products
        public IList<Product> GetProducts()
        {
            IQueryable<Product> _products = from prod in _context.Product
                                            select prod;

            return _products.ToList();
        }

        public Product GetProduct(int id)
        {
            IQueryable<Product> _product;

            _product = from product in _context.Product
                       where product.ProductId == id
                       select product;

            return _product.ToList().First();
        }

        public void AddProduct(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            Product _product = GetProduct(product.ProductId);

            _product.Name = product.Name;
            _product.MeatId = product.MeatId;

            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            Product myProduct = GetProduct(product.ProductId);

            _context.Product.Remove(product);
            _context.SaveChanges();
        }

        // Product BEANs
        public IList<ProductBEAN> GetBEANProducts()
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

        public ProductBEAN GetBEANProduct(int id)
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
        private bool ProductCheck(int id)
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

        public bool AddAPIProduct(Product product)
        {
            try
            { _context.Product.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{ 0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);

                    }

                }

            }

            return true;
        }

        public bool DeleteAPIProduct(Product product)
        {
            if (ProductCheck(product.ProductId) == true)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
                return true;
            }
                else
            {
                return false;

            }
        }

        public bool EditAPIProduct(Product product)
        {
            if (ProductCheck(product.ProductId)== true)
            {
                Product myProduct = GetProduct(product.ProductId);

                myProduct.Name = product.Name;
                myProduct.MeatId = product.MeatId;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        // Product Item
        public IList<ProductItem> GetProductItems()
        {
            IQueryable<ProductItem> _productItems = from proditems in _context.ProductItem
                                                    select proditems;

            return _productItems.ToList();
        }

        public ProductItem GetProductItem(int id)
        {
            IQueryable<ProductItem> _productItem;

            _productItem = from productItem in _context.ProductItem
                           where productItem.ProductItemId == id
                           select productItem;

            return _productItem.ToList().First();
        }

        public void AddProductItem(ProductItem productItem)
        {
            _context.ProductItem.Add(productItem);
            _context.SaveChanges();
        }

        public void EditProductItem(ProductItem productItem)
        {
            ProductItem myProductItem = GetProductItem(productItem.ProductItemId);

            myProductItem.ProductId = productItem.ProductId;
            myProductItem.Cost = productItem.Cost;
            myProductItem.MeasurementId = productItem.MeasurementId;
            myProductItem.Discontinued = productItem.Discontinued;
            myProductItem.ProductId = productItem.ProductId;
            myProductItem.StockQty = productItem.StockQty;

            _context.SaveChanges();
        }

        public void DeleteProductItem(ProductItem productItem)
        {
            _context.ProductItem.Remove(productItem);
            _context.SaveChanges();
        }

        // ProductItem BEANs
        public IList<ProductItemBEAN> GetBEANProductItems()
        {
            IQueryable<ProductItemBEAN> _productItemBEANs = from proditems in _context.ProductItem
                                                            from prod in _context.Product
                                                            from measure in _context.Measurement
                                                            where proditems.ProductId == prod.ProductId
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

        // Only shows product items that haven't been discontinued
        public IList<ProductItemBEAN> GetBEANActiveProductItems()
        {
            IQueryable<ProductItemBEAN> _productItemBEANs = from proditems in _context.ProductItem
                                                            from prod in _context.Product
                                                            from measure in _context.Measurement
                                                            where proditems.Discontinued == false
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

        // Only shows product items that have been discontinued
        public IList<ProductItemBEAN> GetBEANDiscontinuedProductItems()
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

        public ProductItemBEAN GetBEANProductItem(int id)
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
                                                               MeasurementName = measure.MeasurementName,
                                                               Discontinued = proditems.Discontinued,
                                                               ProductId = prod.ProductId,
                                                               StockQty = proditems.StockQty
                                                           };

            return _productItemBEAN.ToList().First();
        }

        // ProductItem APIs
        private bool ProductItemCheck(int id)
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

        public bool AddAPIProductItem(ProductItem productItem)
        {
            try
            {
                _context.ProductItem.Add(productItem);
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

        public bool DeleteAPIProductItem(ProductItem productItem)
        {
            if (MeatCheck(productItem.ProductItemId) == true)
            {
                _context.ProductItem.Remove(productItem);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditAPIProductItem(ProductItem productItem)
        {
            if (ProductItemCheck(productItem.ProductItemId)== true)
            {
                ProductItem myProductItem = GetProductItem(productItem.ProductItemId);

                myProductItem.ProductItemId = productItem.ProductItemId;
                myProductItem.ProductId = productItem.ProductId;
                myProductItem.Cost = productItem.Cost;
                myProductItem.MeasurementId = productItem.MeasurementId;
                myProductItem.Discontinued = productItem.Discontinued;
                myProductItem.StockQty = productItem.StockQty;
                return true;

            }
            else
            {
                return false;
            }

        }


        // Measurement
        public IList<Measurement> GetMeasurements()
        {
            IQueryable<Measurement> _measurements = from measurements in _context.Measurement
                                                    select measurements;

            return _measurements.ToList();
        }

        public Measurement GetMeasurement(int id)
        {
            IQueryable<Measurement> _measurement;

            _measurement = from measurement in _context.Measurement
                           where measurement.MeasurementId == id
                           select measurement;

            return _measurement.ToList().First();
        }

        public void AddMeasurement(Measurement measurement)
        {
            _context.Measurement.Add(measurement);
            _context.SaveChanges();
        }

        public void EditMeasurement(Measurement measurement)
        {
            Measurement myMeasurement = GetMeasurement(measurement.MeasurementId);

            myMeasurement.MeasurementName = measurement.MeasurementName;
            myMeasurement.GramsPerMeasurement = measurement.GramsPerMeasurement;

            _context.SaveChanges();
        }

        public void DeleteMeasurement(Measurement measurement)
        {
            _context.Measurement.Remove(measurement);
            _context.SaveChanges();
        }

        // ProductItem BEANs
        public IList<MeasurementBEAN> GetBEANMeasurements()
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

        public MeasurementBEAN GetBEANMeasurement(int id)
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

        // ProductItem APIs
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

        public bool AddAPIMeasurement(Measurement measurement)
        {
            try
            {
                _context.Measurement.Add(measurement);
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


        public bool EditAPIMeasurement(Measurement measurement)
        {
            if (MeasurementCheck(measurement.MeasurementId) == true)
            {
                Measurement myMeasurement = GetMeasurement(measurement.MeasurementId);

                myMeasurement.MeasurementName = measurement.MeasurementName;
                myMeasurement.GramsPerMeasurement = measurement.GramsPerMeasurement;

                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAPIMeasurement(Measurement measurement)
        {
            if (MeasurementCheck(measurement.MeasurementId) == true)
            {
                _context.Measurement.Remove(measurement);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
