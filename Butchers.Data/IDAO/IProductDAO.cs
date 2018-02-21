﻿using Butchers.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.IDAO
{
    public interface IProductDAO
    {
        // Meats
        IList<Meat> GetMeats();
        Meat GetMeat(int id);
        void AddMeat(Meat meat);
        void EditMeat(Meat meat);
        void DeleteMeat(Meat meat);

        // Products
        IList<ProductBEAN> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(Product product);


        // Product Items
        IList<ProductItemBEAN> GetProductItems();
        ProductItem GetProductItem(int id);
        void AddProductItem(ProductItem productItem);
        void EditProductItem(ProductItem productItem);
        void DeleteProductItem(ProductItem productItem);
    }



}
