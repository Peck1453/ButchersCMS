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
            _context.Meat.SaveChanges();   //Got rid of the error here by adding .Meat - Should work shouldn't it? -AP
        }

        public void EditMeat(Meat meat)
        {
            Meat myMeat = GetMeat(meat.Id);

            myMeat.Name = meat.Name;
            _context.Meat.SaveChanges();   //As Above -AP
        }


        // Product Methods begin here

        public IList<Product> GetProducts()
        {
            IQueryable<Product> _products;
            _products = from product
                        in _context.Product
                        select product;
            return _products.ToList();



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
            _context.Product.SaveChanges(product);

        }

        public void EditProduct(Product product)
        {
            _context.Product.Edit(product);
            _context.Product.SaveChanges(product);


        }


    }
}
