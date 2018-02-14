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

        public void AddMeat(Meat meat)
        {
            _productDAO.AddMeat(meat);
        }
    }
}
