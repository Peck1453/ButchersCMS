using Butchers.Data;
using Butchers.Data.DAO;
using Butchers.Data.IDAO;
using Butchers.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Services.Service
{
    public class ProductService : IProductService
    {
        private IProductDAO _productDAO;

        public ProductService()
        {
            _productDAO = new ProductDAO();
        }

        public IList<Meat> GetMeats()
        {
            return _productDAO.GetMeats();
        }

        public Meat GetMeat(int id)
        {
            return _productDAO.GetMeat(id);
        }

        public void AddMeat(Meat meat)
        {
            _productDAO.AddMeat(meat);
        }

        public void EditMeat(Meat meat)
        {
            _productDAO.EditMeat(meat);
        }

        public void DeleteMeat(Meat meat)
        {
            _productDAO.DeleteMeat(meat);
        }


        // Products start here

        public IList<Product> GetProducts()
        {
            return _productDAO.GetProducts();
        }

        public Product GetProduct(int id)
        {

            return _productDAO.GetProduct(id);
        }

        public void AddProduct(Product product)
        {
            _productDAO.AddProduct(product);

        }

        public void EditProduct(Product product)
        {

            _productDAO.EditProduct(product);
        }

    }
}
