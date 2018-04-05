﻿using Butchers.Data;
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

        public bool DeleteAPIPromoCode(PromoCode code)
        {
            return _orderDAO.DeleteAPIPromocode(code);
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

        // CartItem APIs
        public bool AddAPICartItem(CartItem cartItem)
        {
            return _orderDAO.AddAPICartItem(cartItem);
        }

        public bool DeleteAPICartItem(CartItem cartItem)
        {
            return _orderDAO.DeleteAPICartItem(cartItem);
        }

        public bool EditAPICartItem(CartItem cartItem)
        {

            if (_orderDAO.EditAPICartItem(cartItem) == true)
                return true;
            else
                return false;

        }
        //Cart
        public IList<Cart> GetCarts()
        {
            return _orderDAO.GetCarts();
        }

        public Cart GetCart(int id)
        {
            return _orderDAO.GetCart(id);
        }

        public void AddCart(Cart cart)
        {
            _orderDAO.AddCart(cart);
        }

        public int AddCartAndReturnId(Cart cart)
        {
            return _orderDAO.AddCartAndReturnId(cart);
        }

        public void EditCart(Cart cart)
        {
            _orderDAO.EditCart(cart);
        }

        public void DeleteCart(Cart cart)
        {
            _orderDAO.DeleteCart(cart);
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

        // Cart APIs
        public bool AddAPICart(Cart cart)
        {
            return _orderDAO.AddAPICart(cart);
        }

        public bool EditAPICart(Cart cart)
        {
            if (_orderDAO.EditAPICart(cart) == true)
                return true;
            else
                return false;
        }

        public bool DeleteAPICart(Cart cart)
        {
            return _orderDAO.DeleteAPICart(cart);
        }

        // Order
        public IList<Order> GetOrders()
        {
            return _orderDAO.GetOrders();
        }

        public Order GetOrder(int id)
        {
            return _orderDAO.GetOrder(id);
        }

        public void AddOrder(Order order)
        {
            _orderDAO.AddOrder(order);
        }

        public int AddOrderAndReturnId(Order order)
        {
            return _orderDAO.AddOrderAndReturnId(order);
        }

        public void EditOrder(Order order)
        {
            _orderDAO.EditOrder(order);
        }

        public void DeleteOrder(Order order)
        {
            _orderDAO.DeleteOrder(order);
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

        //OrderAPIs

       public bool AddAPIOrder(Order order)
        {
            return _orderDAO.AddAPIOrder(order);

        }

        public bool EditAPIOrder(Order orders)
        {
            if (_orderDAO.EditAPIOrder(orders) == true)
                return true;
            else
                return false;
        }

        public bool DeleteAPIOrder(Order order)
        {
            return _orderDAO.DeleteAPIOrder(order);
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

        public void DeleteOrderDetails(OrderDetails details)
        {
            _orderDAO.DeleteOrderDetails(details);
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

        // OrderDetails APIs 
        public bool AddAPIOrderDetails(OrderDetails details)
        {
            return _orderDAO.AddAPIOrderDetails(details);
        }

        public bool EditAPIOrderDetails(OrderDetails orderDetails)
        {
            if (_orderDAO.EditAPIOrderDetails(orderDetails) == true)
                return true;
            else
                return false;
        }

        public bool DeleteAPIOrderDetails(OrderDetails details)
        {
            return _orderDAO.DeleteAPIOrderDetails(details);
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
