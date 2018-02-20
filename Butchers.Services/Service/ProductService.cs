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

        // Meats
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


        // Products
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

        // Delete goes here

        // Product Item
        public IList<ProductItem> GetProductItems()
        {
            return _productDAO.GetProductItems();
        }

        public ProductItem GetProductItem(int id)
        {

            return _productDAO.GetProductItem(id);
        }

        public void AddProductItem(ProductItem productItem)
        {
            _productDAO.AddProductItem(productItem);

        }

        public void EditProductItem(ProductItem productItem)
        {
            _productDAO.EditProductItem(productItem);
        }

        public void DeleteProductItem(ProductItem productItem)
        {
            _productDAO.DeleteProductItem(productItem);
        }
    }
}
