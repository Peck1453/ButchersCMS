using Butchers.Data;
using Butchers.Data.BEANS;
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
        public IList<MeatBEAN> GetBEANMeats()
        {

            return _productDAO.GetBEANMeats();
        }
        public MeatBEAN GetBEANMeat(int id)
        {

            return _productDAO.GetBEANMeat(id);

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

        // Meat BEANs
            //Put things relating to meat bean here

        // Meat APIs
        public bool AddAPIMeat(Meat meat)
        {
            if (_productDAO.AddAPIMeat(meat) == true)
                return true;
            else
                return false;
        }

        public bool DeleteAPIMeat(Meat meat)
        {
            if (_productDAO.DeleteAPIMeat(meat) == true)
                return true;
            else
                return false;
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


        public void DeleteProduct(Product product)
        {
            _productDAO.DeleteProduct(product);
        }

        // Product BEANs
        public IList<ProductBEAN> GetBEANProducts()
        {
            return _productDAO.GetBEANProducts();
        }

        public ProductBEAN GetBEANProduct(int id)
        {
            return _productDAO.GetBEANProduct(id);
        }

        // Product APIs
            // Put product API things here

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

        // ProductItem BEANs
        public IList<ProductItemBEAN> GetBEANProductItems()
        {
            return _productDAO.GetBEANProductItems();
        }

        public ProductItemBEAN GetBEANProductItem(int id)
        {
            return _productDAO.GetBEANProductItem(id);
        }

        // ProductItem APIs
            // Put product item api stuff here
    }
}
