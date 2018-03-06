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


        //PromoCode

        public IList<PromoCode> GetPromoCodes()
        {
            return _orderDAO.GetPromoCodes();
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

        //PromocodeBEANS 

        public PromoCodeBEAN GetBEANPromoCode(string id)
        {
            return _orderDAO.GetBEANPromoCode(id);
        }

        public IList<PromoCodeBEAN> GetBEANPromoCodes()
        {
            return _orderDAO.GetBEANPromoCodes();
        }


        //Promocode APIS 

        

        public bool DeleteAPIPromoCode(PromoCode code)
        {

            return _orderDAO.DeleteAPIPromocode(code);

        }

        public bool AddAPIPromocode(PromoCode code)
         {
          return _orderDAO.AddAPIPromocode(code);

        }





        // Cart Items
        //public IList<CartItem> GetCartItems()
        //{
        //    return _orderDAO.GetCartItems();
        //}

        //public IList<CartItemBEAN> GetBEANCartItems()
        //{
        //    return _orderDAO.GetBEANCartItems();
        //}

        //public CartItem GetCartItem(int id)
        //{
        //    return _orderDAO.GetCartItem(id);
        //}

        //public CartItemBEAN GetBEANCartItem (int id)
        //{
        //    return _orderDAO.GetBEANCartItem(id);
        //}

        //public void AddCartItem (CartItem cartItem)
        //{
        //    _orderDAO.AddCartItem(cartItem);
        //}

        //public void  EditCartItem(CartItem cartItem)
        //{
        //    _orderDAO.EditCartItem(cartItem);
        //}

        //public void DeleteCartItem(CartItem cartItem)

        //{
        //    _orderDAO.DeleteCartItem(cartItem);
        //}

        // Order
        //public IList<Order> GetOrders()
        //{
        //    return _orderDAO.GetOrders();
        //}

        //public IList<OrderBEAN> GetBEANOrders()
        //{
        //    return _orderDAO.GetBEANOrders();
        //}

        //public Order GetOrder(int id)
        //{
        //    return _orderDAO.GetOrder(id);
        //}

        //public OrderBEAN GetBEANOrder(int id)
        //{
        //    return _orderDAO.GetBEANOrder(id);
        //}

        //public void AddOrder(Order order)
        //{
        //    _orderDAO.AddOrder(order);
        //}
        //public void EditOrder(Order order)
        //{
        //    _orderDAO.EditOrder(order);
        //}
        //public void DeleteOrder(Order order)
        //{
        //    _orderDAO.DeleteOrder(order);
        //}

    }
}
