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
        public int CountMeats()
        {
            return _productDAO.CountMeats();
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

        // Meat BEANs
        public IList<MeatBEAN> GetBEANMeats()
        {
            return _productDAO.GetBEANMeats();
        }

        public MeatBEAN GetBEANMeat(int id)
        {
            return _productDAO.GetBEANMeat(id);
        }

        // Products
        public IList<Product> GetProducts()
        {
            return _productDAO.GetProducts();
        }
        public int CountProducts()
        {
            return _productDAO.CountProducts();
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

        // Product Item
        public IList<ProductItem> GetProductItems()
        {
            return _productDAO.GetProductItems();
        }

        public int CountProductItems()
        {
            return _productDAO.CountProductItems();
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

        public void ToggleProductItem(ProductItem productItem)
        {
            _productDAO.ToggleProductItem(productItem);
        }

        // ProductItem BEANs
        public IList<ProductItemBEAN> GetBEANProductItems()
        {
            return _productDAO.GetBEANProductItems();
        }

        public IList<ProductItemBEAN> GetBEANProductItemsTopStock()
        {
            return _productDAO.GetBEANProductItemsTopStock();
        }

        public IList<ProductItemBEAN> GetBEANProductItemsLowStock()
        {
            return _productDAO.GetBEANProductItemsLowStock();
        }

        public IList<ProductItemBEAN> GetBEANProductItemsActive()
        {
            return _productDAO.GetBEANProductItemsActive();
        }

        public IList<ProductItemBEAN> GetBEANDiscontinuedProductItems()
        {
            return _productDAO.GetBEANDiscontinuedProductItems();
        }

        public ProductItemBEAN GetBEANProductItem(int id)
        {
            return _productDAO.GetBEANProductItem(id);
        }

        public bool EditAPIProductItem(ProductItem productItem)
        {
            if (_productDAO.EditAPIProductItem(productItem) == true)
                return true;

            else return false;
        }

        // Measurements
        public IList<Measurement> GetMeasurements()
        {
            return _productDAO.GetMeasurements();
        }

        public Measurement GetMeasurement(int id)
        {
            return _productDAO.GetMeasurement(id);
        }

        public void AddMeasurement(Measurement measurement)
        {
            _productDAO.AddMeasurement(measurement);
        }

        public void EditMeasurement(Measurement measurement)
        {
            _productDAO.EditMeasurement(measurement);
        }

        public void DeleteMeasurement(Measurement measurement)
        {
            _productDAO.DeleteMeasurement(measurement);
        }

        // Meat BEANs
        public IList<MeasurementBEAN> GetBEANMeasurements()
        {
            return _productDAO.GetBEANMeasurements();
        }
        public MeasurementBEAN GetBEANMeasurement(int id)
        {
            return _productDAO.GetBEANMeasurement(id);
        }
        
        //Stock Transaction
        public void AddStockTransaction(StockTransaction stocktransaction)
        {
            _productDAO.AddStockTransaction(stocktransaction);
        }

        public IList<StockTransaction> GetStockTransactions()
        {
            return _productDAO.GetStockTransactions();
        }

        public StockTransaction GetStockTransaction(int id)
        {
            return _productDAO.GetStockTransaction(id);
        }

        //Stock Transaction BEANs

        public IList<StockTransactionBEAN> GetBEANStockTransactions()
        {
            return _productDAO.GetBEANStockTransactions();
        }

        public StockTransactionBEAN GetBEANStockTransaction(int id)
        {
            return _productDAO.GetBEANStockTransaction(id);
        }

        //Stock Transaction API

        public bool AddAPIStockTransaction(StockTransaction stockTransaction)
        {
            if (_productDAO.AddAPIStockTransaction(stockTransaction) == true)
                return true;
            else
                return false;

        }


    }
}
