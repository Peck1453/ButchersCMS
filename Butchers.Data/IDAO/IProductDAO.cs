using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.IDAO
{
    public interface IProductDAO
    {
        IList<Meat> GetMeats();
        void AddMeat(Meat meat);
        void EditMeat(Meat meat);
        Meat GetMeat(int id);


        IList<Product> GetProducts();

        Product GetProduct(int id);

        void AddProduct(Product product);

        void EditProduct(Product product);
    }



}
