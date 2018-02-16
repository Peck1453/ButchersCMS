using Butchers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Services.IService
{
    public interface IProductService
    {
        IList<Meat> GetMeats();
        Meat GetMeat(int id);
        void AddMeat(Meat meat);
        void EditMeat(Meat meat);

        //products start here

        IList<Product> GetProducts();


        Product GetProduct(int id);

        void AddProduct(Product product);

        void EditProduct(Product product);
    }
}
