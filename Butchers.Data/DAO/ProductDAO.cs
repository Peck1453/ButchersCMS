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

            _meats = from meat
                     in _context.Meat
                     select meat;

            return _meats.ToList();
        }



        public Meat GetMeat(int id)
        {
            IQueryable<Meat> _meat;

            _meat = from meat
                    in _context.Meat
                    where meat.Id == id
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
            Meat myMeat = GetMeat(meat.Id);

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
                                                  Id = mt.Id,
                                                  Name = mt.Name
                                              };

            return _meatBEANs.ToList();


        }

        public MeatBEAN GetBEANMeat(int id)
        {
            {
                IQueryable<MeatBEAN> _meatBEANS = from mt in _context.Meat
                                                  where mt.Id == id
                                                  select new MeatBEAN
                                                  {
                                                      Id = mt.Id,
                                                      Name = mt.Name
                                                  };
                return _meatBEANS.ToList().First();


            }


        }

        // Meat APIs
        private bool MeatCheck(int id)
        {
            IQueryable<int> meatList = from meats in _context.Meat
                                        select meats.Id;

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

        public bool DeleteAPIMeat(Meat meat)
        {
            if (MeatCheck(meat.Id) == true)
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
                       where product.Id == id
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
            Product _product = GetProduct(product.Id);

            _product.Name = product.Name;
            _product.MeatId = product.MeatId;

            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            Product myProduct = GetProduct(product.Id);

            _context.Product.Remove(product);
            _context.SaveChanges();
        }

        // Product BEANs
        public IList<ProductBEAN> GetBEANProducts()
        {
            IQueryable<ProductBEAN> _productBEANs = from prod in _context.Product
                                                    from mt in _context.Meat
                                                    where prod.MeatId == mt.Id
                                                    select new ProductBEAN
                                                    {
                                                        Id = prod.Id,
                                                        Meat = mt.Name,
                                                        MeatId = mt.Id,
                                                        Name = prod.Name
                                                    };

            return _productBEANs.ToList();
        }

        public ProductBEAN GetBEANProduct(int id)
        {
            {
                IQueryable<ProductBEAN> _productBEANs = from prod in _context.Product
                                                        from mt in _context.Meat
                                                        where prod.Id == mt.Id
                                                        select new ProductBEAN
                                                        {
                                                            Id = prod.Id,
                                                            Meat = mt.Name,
                                                            MeatId = mt.Id,
                                                            Name = prod.Name
                                                        };

                return _productBEANs.ToList().First();

            }
        }

        // Product APIs - W.I.P.
        private bool ProductCheck(int id)
        {
            IQueryable<int> productList = from products in _context.Product
                                        select products.Id;
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
            if (ProductCheck(product.Id) == true)
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

            _productItem = from productItem
                            in _context.ProductItem
                           where productItem.Id == id
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
            ProductItem myProductItem = GetProductItem(productItem.Id);

            myProductItem.ProductId = productItem.ProductId;
            myProductItem.Cost = productItem.Cost;
            myProductItem.PerUnit = productItem.PerUnit;
            myProductItem.Discontinued = productItem.Discontinued;
            myProductItem.ProductId = productItem.ProductId;

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
                                                            where proditems.ProductId == prod.Id
                                                            select new ProductItemBEAN
                                                            {
                                                                Id = proditems.Id,
                                                                Product = prod.Name,
                                                                Cost = proditems.Cost,
                                                                PerUnit = proditems.PerUnit,
                                                                Discontinued = proditems.Discontinued,
                                                                ProductId = prod.Id
                                                            };

            return _productItemBEANs.ToList();
        }

        public ProductItemBEAN GetBEANProductItem(int id)
        {
            IQueryable<ProductItemBEAN> _productItemBEAN = from proditems in _context.ProductItem
                                                           from prod in _context.Product
                                                           where proditems.Id == id
                                                           && proditems.ProductId == prod.Id
                                                           select new ProductItemBEAN
                                                           {
                                                               Id = proditems.Id,
                                                               Product = prod.Name,
                                                               Cost = proditems.Cost,
                                                               PerUnit = proditems.PerUnit,
                                                               Discontinued = proditems.Discontinued,
                                                               ProductId = prod.Id
                                                           };

            return _productItemBEAN.ToList().First();
        }

        // ProductItem APIs
            // Add and Delete methods need creating for APIs, put them here.

    }
}
