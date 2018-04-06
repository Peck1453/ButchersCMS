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

        public int CountPromoCodes()
        {
            return _orderDAO.CountPromoCodes();
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

        //PromoCode BEANs
        public PromoCodeBEAN GetBEANPromoCode(string id)
        {
            return _orderDAO.GetBEANPromoCode(id);
        }

        public IList<PromoCodeBEAN> GetBEANPromoCodes()
        {
            return _orderDAO.GetBEANPromoCodes();
        }

        //Promocode APIs 
        public bool AddAPIPromocode(PromoCode code)
        {
            return _orderDAO.AddAPIPromocode(code);
        }

        public bool EditAPIPromocode(PromoCode code)
        {
            if (_orderDAO.EditAPIPromocode(code) == true)
                return true;
            else
                return false;
        }

        // Cart Items
        public IList<CartItem> GetCartItems()
        {
            return _orderDAO.GetCartItems();
        }

        public IList<CartItemBEAN> GetCartItemsByCartId(int cartId)
        {
            return _orderDAO.GetCartItemsByCartId(cartId);
        }

        public CartItem GetCartItem(int id)
        {
            return _orderDAO.GetCartItem(id);
        }

        public void AddCartItem(CartItem cartItem)
        {
            _orderDAO.AddCartItem(cartItem);
        }

        public void EditCartItem(CartItem cartItem)
        {
            _orderDAO.EditCartItem(cartItem);
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _orderDAO.DeleteCartItem(cartItem);
        }

        // CartItem BEANs
        public IList<CartItemBEAN> GetBEANCartItems()
        {
            return _orderDAO.GetBEANCartItems();
        }

        public CartItemBEAN GetBEANCartItem(int id)
        {
            return _orderDAO.GetBEANCartItem(id);
        }

        //Cart
        public IList<Cart> GetCarts()
        {
            return _orderDAO.GetCarts();
        }
        public int CountCarts()
        {
            return _orderDAO.CountCarts();
        }

        public Cart GetCart(int id)
        {
            return _orderDAO.GetCart(id);
        }

        public int AddCartAndReturnId(Cart cart)
        {
            return _orderDAO.AddCartAndReturnId(cart);
        }

        // Cart BEANs
        public IList<CartBEAN> GetBEANCarts()
        {
            return _orderDAO.GetBEANCarts();
        }

        public CartBEAN GetBEANCart(int id)
        {
            return _orderDAO.GetBEANCart(id);
        }

        // Order
        public IList<Order> GetOrders()
        {
            return _orderDAO.GetOrders();
        }
        public int CountOrders()
        {
            return _orderDAO.CountOrders();
        }

        public Order GetOrder(int id)
        {
            return _orderDAO.GetOrder(id);
        }

        //public void AddOrder(Order order)
        //{
        //    _orderDAO.AddOrder(order);
        //}

        public int AddOrderAndReturnId(Order order)
        {
            return _orderDAO.AddOrderAndReturnId(order);
        }

        //OrderBEAN
        public IList<OrderBEAN> GetBEANOrders()
        {
            return _orderDAO.GetBEANOrders();
        }

        public IList<OrderBEAN> GetBEANCustomerOrders(string uid)
        {
            return _orderDAO.GetBEANCustomerOrders(uid);
        }

        public OrderBEAN GetBEANOrder(int id)
        {
            return _orderDAO.GetBEANOrder(id);
        }

        // Order Details
        public IList<OrderDetails> GetOrderDetails()
        {
            return _orderDAO.GetOrderDetails();
        }

        public OrderDetails GetOrderDetail(int id)
        {
            return _orderDAO.GetOrderDetail(id);
        }

        public OrderDetails ToggleCollected(int id)
        {
            return _orderDAO.ToggleCollected(id);
        }

        public void AddOrderDetails(OrderDetails details)
        {
            _orderDAO.AddOrderDetails(details);
        }

        public void EditOrderDetails(OrderDetails details)
        {
            _orderDAO.EditOrderDetails(details);
        }

        // OrderDetails BEANs
        public IList<OrderDetailsBEAN> GetBEANOrderDetails()
        {
            return _orderDAO.GetBEANOrderDetails();
        }

        public OrderDetailsBEAN GetBEANOrderDetail(int id)
        {
            return _orderDAO.GetBEANOrderDetail(id);
        }

        // Calculations
        public decimal GetCartCost(int cartId)
        {
            return _orderDAO.GetCartCost(cartId);
        }

        public decimal GetCostAfterDiscount(decimal currentTotal, string promoCode)
        {
            return _orderDAO.GetCostAfterDiscount(currentTotal, promoCode);
        }
    }
}
