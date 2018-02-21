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
    public class OrderService : IOrderService
    {
        private IOrderDAO _orderDAO;

        public OrderService()
        {
            _orderDAO = new OrderDAO();
        }

        public IList<PromoCodeBEAN> GetPromoCodes()
        {
            return _orderDAO.GetPromoCodes();
        }

        public PromoCodeBEAN GetPromoCodeBEAN(string id)
        {
            return _orderDAO.GetPromoCodeBEAN(id);
        }

        public PromoCode GetPromoCode(string id)
        {
            return _orderDAO.GetPromoCode(id);
        }

        public void AddPromoCode(PromoCode code)
        {
            _orderDAO.AddPromoCode(code);
        }
        public void EditPromoCode(PromoCode code)
        {
            _orderDAO.EditPromoCode(code);
        }
        public void DeletePromoCode(PromoCode code)
        {
            _orderDAO.DeletePromoCode(code);
        }

        //cart Items
        public IList<CartItemBEAN> GetCartItems()
        {
            return _orderDAO.GetCartItems();
        }

    }
}
