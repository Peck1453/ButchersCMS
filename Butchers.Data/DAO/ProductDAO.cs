using Butchers.Data.BEANS;
using Butchers.Data.IDAO;
using System;
using System.Collections.Generic;
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

        // Products
        public IList<Product> GetProducts()
        {
            IQueryable<Product> _products = from prod in _context.Product
                                            select prod;

            return _products.ToList();
        }

        public IList<ProductBEAN> GetBEANProducts()
        {
            IQueryable<ProductBEAN> _productBEANs = from prod in _context.Product
                                                    from mt in _context.Meat
                                                    where prod.MeatId == mt.Id
                                                    select new ProductBEAN
                                                    {
                                                        Id = prod.Id,
                                                        Meat = mt.Name,
                                                        Name = prod.Name
                                                    };

            return _productBEANs.ToList();
        }

        public Product GetProduct(int id)
        {
            IQueryable<Product> _product;

            _product = from product in _context.Product
                       where product.Id == id
                       select product;

            return _product.ToList().First();
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

        // Product Item
        public IList<ProductItem> GetProductItems()
        {
            IQueryable<ProductItem> _productItems = from proditems in _context.ProductItem
                                                    select proditems;

            return _productItems.ToList();
        }

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

        public ProductItem GetProductItem(int id)
        {
            IQueryable<ProductItem> _productItem;

            _productItem = from productItem
                            in _context.ProductItem
                           where productItem.Id == id
                           select productItem;

            return _productItem.ToList().First();
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

    }
}
