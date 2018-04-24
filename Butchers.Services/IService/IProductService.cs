using Butchers.Data;
using Butchers.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Services.IService
{
    public interface IProductService
    {
        // Meats
        IList<Meat> GetMeats();
        int CountMeats();
        Meat GetMeat(int id);
        void AddMeat(Meat meat);
        void EditMeat(Meat meat);
        void DeleteMeat(Meat meat);

        // Meat BEANs
        IList<MeatBEAN> GetBEANMeats();
        MeatBEAN GetBEANMeat(int id);

        // Products
        IList<Product> GetProducts();
        int CountProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(Product product);

        // Product BEANs
        IList<ProductBEAN> GetBEANProducts();
        ProductBEAN GetBEANProduct(int id);

        // ProductItems
        IList<ProductItem> GetProductItems();
        int CountProductItems();
        ProductItem GetProductItem(int id);
        void AddProductItem(ProductItem productItem);
        void EditProductItem(ProductItem productItem);
        void ToggleProductItem(ProductItem productItem, string user);

        // ProductItem BEANs
        IList<ProductItemBEAN> GetBEANProductItems();
        IList<ProductItemBEAN> GetBEANProductItemsTopStock();
        IList<ProductItemBEAN> GetBEANProductItemsLowStock();
        IList<ProductItemBEAN> GetBEANProductItemsActive();
        IList<ProductItemBEAN> GetBEANDiscontinuedProductItems();
        ProductItemBEAN GetBEANProductItem(int id);

        // ProductItem APIs
        bool EditAPIProductItem(ProductItem productItem);

        // Measurements
        IList<Measurement> GetMeasurements();
        Measurement GetMeasurement(int id);
        void AddMeasurement(Measurement measurement);
        void EditMeasurement(Measurement measurement);
        void DeleteMeasurement(Measurement measurement);

        // Measurement BEANs
        IList<MeasurementBEAN> GetBEANMeasurements();
        MeasurementBEAN GetBEANMeasurement(int id);

        //Stock Transaction
        IList<StockTransaction> GetStockTransactions();
        StockTransaction GetStockTransaction(int id);
        void AddStockTransaction(StockTransaction stocktransaction);

        //Stock Transaction BEANs
        IList<StockTransactionBEAN> GetBEANStockTransactions();
        StockTransactionBEAN GetBEANStockTransaction(int id);

        //Stock Transaction API

        bool AddAPIStockTransaction(StockTransaction stockTransaction);

    }

}
