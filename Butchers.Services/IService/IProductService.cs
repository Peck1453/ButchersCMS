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
    {// Meats
        IList<Meat> GetMeats();
        Meat GetMeat(int id);
        void AddMeat(Meat meat);
        void EditMeat(Meat meat);
        void DeleteMeat(Meat meat);

        // Meat BEANs
        IList<MeatBEAN> GetBEANMeats();
        MeatBEAN GetBEANMeat(int id);

        // Meat APIs
        bool AddAPIMeat(Meat meat);
        bool EditAPIMeat(Meat meat);
        bool DeleteAPIMeat(Meat meat);

        // Products
        IList<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(Product product);

        // Product BEANs
        IList<ProductBEAN> GetBEANProducts();
        ProductBEAN GetBEANProduct(int id);

        // Product APIs
        bool AddAPIProduct(Product product);
        bool DeleteAPIProduct(Product product);
        bool EditAPIProduct(Product product);


        // ProductItems
        IList<ProductItem> GetProductItems();
        ProductItem GetProductItem(int id);
        void AddProductItem(ProductItem productItem);
        void EditProductItem(ProductItem productItem);
        void DeleteProductItem(ProductItem productItem);

        // ProductItem BEANs
        IList<ProductItemBEAN> GetBEANProductItems();
        IList<ProductItemBEAN> GetBEANActiveProductItems();
        IList<ProductItemBEAN> GetBEANDiscontinuedProductItems();
        ProductItemBEAN GetBEANProductItem(int id);

        // ProductItem APIs
        bool AddAPIProductItem(ProductItem productItem);
        bool DeleteAPIProductItem(ProductItem productItem);
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

        // Measurement APIs
        bool AddAPIMeasurement(Measurement measurement);
        bool EditAPIMeasurement(Measurement measurement);
        bool DeleteAPIMeasurement(Measurement measurement);
    }
}
