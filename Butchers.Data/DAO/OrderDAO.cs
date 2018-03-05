﻿using Butchers.Data.BEANS;
using Butchers.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.DAO
{
    public class OrderDAO : IOrderDAO
    {

        private ButchersEntities _context;
        public OrderDAO()
        {
            _context = new ButchersEntities();
        }

        public IList<PromoCode> GetPromoCodes()
        {
            IQueryable<PromoCode> _promoCodes;

            _promoCodes = from code in _context.PromoCode
                          select code;

            return _promoCodes.ToList();
        }

        public IList<PromoCodeBEAN> GetBEANPromoCodes()
        {
            IQueryable<PromoCodeBEAN> _promoCodeBEANs;
            _promoCodeBEANs = from code in _context.PromoCode
                              select new PromoCodeBEAN
                              {
                                  Code = code.PromoCode1,
                                  Discount = code.Discount,
                                  ValidUntil = code.ValidUntil
                              };

            return _promoCodeBEANs.ToList();
        }

        public PromoCode GetPromoCode(string Id)
        {
            IQueryable<PromoCode> _code;

            _code = from pcode in _context.PromoCode
                    where pcode.PromoCode1 == Id
                    select pcode;

            return _code.ToList().First();
        }

        public PromoCodeBEAN GetBEANPromoCode(string id)
        {
            IQueryable<PromoCodeBEAN> _codeBEAN;

            _codeBEAN = from pcode in _context.PromoCode
                        where pcode.PromoCode1 == id
                        select new PromoCodeBEAN
                        {
                            Code = pcode.PromoCode1,
                            Discount = pcode.Discount,
                            ValidUntil = pcode.ValidUntil
                        };

            return _codeBEAN.ToList().First();
        }

        public void AddPromoCode(PromoCode code)
        {
            _context.PromoCode.Add(code);
            _context.SaveChanges();
        }

        public void EditPromoCode(PromoCode pcode)
        {

            PromoCode _code = GetPromoCode(pcode.PromoCode1);
            _code.Discount = pcode.Discount;
            _code.ValidUntil = pcode.ValidUntil;

            _context.SaveChanges();
        }
        public void DeletePromoCode(PromoCode code)
        {
            _context.PromoCode.Remove(code);
            _context.SaveChanges();
        }

        // Cart Item
        public IList<CartItem> GetCartItems()
        {
            IQueryable<CartItem> _cartItems = from cart in _context.CartItem
                                              select cart;

            return _cartItems.ToList();
        }
        public IList<CartItemBEAN> GetBEANCartItems()
        {
            IQueryable<CartItemBEAN> _cartItemBEANs = from cart in _context.CartItem
                                                      from prod in _context.Product
                                                      where cart.ProductItemId == prod.ProductId
                                                      select new CartItemBEAN
                                                      {
                                                          Id = cart.CartItemId,
                                                          ProductItem = prod.Name,
                                                          ProductItemId = prod.ProductId,
                                                          Quantity = cart.Quantity
                                                      };

            return _cartItemBEANs.ToList();
        }

        public CartItem GetCartItem(int id)
        {
            IQueryable<CartItem> _cart;
            _cart = from cart in _context.CartItem
                    where cart.ProductItemId == id
                    select cart;

            return _cart.ToList().First();

        }

        public CartItemBEAN GetBEANCartItem(int id)
        {
            IQueryable<CartItemBEAN> _cartBEAN;
            _cartBEAN = from cartItem in _context.CartItem
                        from prod in _context.Product
                        select new CartItemBEAN
                        {
                            Id = cartItem.CartItemId,
                            ProductItem = prod.Name,
                            ProductItemId = prod.ProductId,
                            Quantity = cartItem.Quantity
                        };

            return _cartBEAN.ToList().First();

        }

        public CartItem GetProductItem(int id)
        {
            IQueryable<CartItem> _Cartitems = from cartItem in _context.CartItem
                                              where cartItem.CartItemId == id
                                              select cartItem;

            return _Cartitems.ToList().First();
         }

        public void AddCartItem(CartItem cartItem)
        {
            _context.CartItem.Add(cartItem);
            _context.SaveChanges();
        }

        public void EditCartItem(CartItem cartItem)
        {
            CartItem _Cartitems = GetProductItem(cartItem.CartItemId);
            _Cartitems.Quantity = cartItem.Quantity;
            
            _context.SaveChanges();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _context.CartItem.Remove(cartItem);
            _context.SaveChanges();
        }

        // Order
        public IList<Order> GetOrders()
        {
            IQueryable<Order> _orders;

            _orders = from order in _context.Order
                      select order;

            return _orders.ToList();
        }
        public IList<OrderBEAN> GetBEANOrders()
        {
            IQueryable<OrderBEAN> _orderBEANs;

            _orderBEANs = from order in _context.Order
                          from code in _context.PromoCode
                          where order.PromoCode == code.PromoCode1
                          select new OrderBEAN
                          {
                              Id = order.OrderNo,
                              OrderDate = order.OrderDate,
                              Customer = order.CustomerNo,
                              PromoCode = code.PromoCode1,
                              TotalCost = order.TotalCost
                          };

            return _orderBEANs.ToList();
        }

        public Order GetOrder(int id)
        {
            IQueryable<Order> _order;

            _order = from order in _context.Order
                     where order.OrderNo == id
                     select order;

            return _order.ToList().First();
        }

        public OrderBEAN GetBEANOrder(int id)
        {
            IQueryable<OrderBEAN> _orderBEAN;

            _orderBEAN = from order in _context.Order
                         from code in _context.PromoCode
                         where order.OrderNo == id
                         && order.PromoCode == code.PromoCode1
                         select new OrderBEAN
                         {
                             Id = order.OrderNo,
                             OrderDate = order.OrderDate,
                             Customer = order.CustomerNo,
                             PromoCode = code.PromoCode1,
                             TotalCost = order.TotalCost
                         };

            return _orderBEAN.ToList().First();
        }

        public void AddOrder(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
        }

        public void EditOrder(Order order)
        {

            Order _order = GetOrder(order.OrderNo);

            _order.OrderDate = order.OrderDate;
            _order.CustomerNo = order.CustomerNo;
            _order.PromoCode = order.PromoCode;
            _order.TotalCost = order.TotalCost;

            _context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            _context.Order.Remove(order);
            _context.SaveChanges();
        }
    }

}
