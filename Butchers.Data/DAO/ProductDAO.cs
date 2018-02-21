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
        public IList<ProductBEAN> GetProducts()
        {
            IQueryable<ProductBEAN> _productBEANs = from prod in _context.Product
                                     from mt in _context.Meat
                                     where prod.MeatId == mt.Id
                                     select new ProductBEAN
                                     {
                                       Id = prod.Id,
                                       MeatId = mt.Name,
                                       Name = prod.Name
                                     };

            return _productBEANs.ToList();
        }

        public Product GetProduct(int id)
        {
            IQueryable<Product> _product;

            _product = from product
                       in _context.Product
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
            Product myProduct = GetProduct(product.Id);

            myProduct.Name = product.Name;
            myProduct.MeatId = product.MeatId;

            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            Product myProduct = GetProduct(product.Id);

            _context.Product.Remove(product);
            _context.SaveChanges();
        }


        // Product Item
        public IList<ProductItemBEAN> GetProductItems()
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
                                                                Discontinued = proditems.Discontinued
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

            _context.SaveChanges();
        }

        public void DeleteProductItem(ProductItem productItem)
        {
            _context.ProductItem.Remove(productItem);
            _context.SaveChanges();
        }
    }
}
