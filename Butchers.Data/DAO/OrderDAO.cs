using Butchers.Data.BEANS;
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
                                  Code = code.Code,
                                  Discount = code.Discount,
                                  ValidUntil = code.ValidUntil
                              };

            return _promoCodeBEANs.ToList();
        }

        public PromoCode GetPromoCode(string Id)
        {
            IQueryable<PromoCode> _code;

            _code = from pcode in _context.PromoCode
                    where pcode.Code == Id
                    select pcode;

            return _code.ToList().First();
        }

        public PromoCodeBEAN GetBEANPromoCode(string id)
        {
            IQueryable<PromoCodeBEAN> _codeBEAN;

            _codeBEAN = from pcode in _context.PromoCode
                        where pcode.Code == id
                        select new PromoCodeBEAN
                        {
                            Code = pcode.Code,
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

            PromoCode _code = GetPromoCode(pcode.Code);
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
                                                      where cart.ProductItem == prod.Id
                                                      select new CartItemBEAN
                                                      {
                                                          Id = cart.Id,
                                                          ProductItem = prod.Name,
                                                          ProductItemId = prod.Id,
                                                          Quantity = cart.Quantity,
                                                          DateAdded = cart.DateAdded
                                                      };

            return _cartItemBEANs.ToList();
        }

        public CartItem GetCartItem(int id)
        {
            IQueryable<CartItem> _cart;
            _cart = from cart in _context.CartItem
                    where cart.ProductItem == id
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
                            Id = cartItem.Id,
                            ProductItem = prod.Name,
                            ProductItemId = prod.Id,
                            Quantity = cartItem.Quantity,
                            DateAdded = cartItem.DateAdded
                        };

            return _cartBEAN.ToList().First();

        }

        public CartItem GetProductItem(int id)
        {
            IQueryable<CartItem> _Cartitems = from cartItem in _context.CartItem
                                              where cartItem.Id == id
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
            CartItem _Cartitems = GetProductItem(cartItem.Id);
            _Cartitems.Quantity = cartItem.Quantity;
            _Cartitems.DateAdded = cartItem.DateAdded;
            
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
                          where order.PromoCode == code.Code
                          select new OrderBEAN
                          {
                              Id = order.Id,
                              OrderDate = order.OrderDate,
                              CollectFrom = order.CollectFrom,
                              CollectBy = order.CollectBy,
                              Customer = order.Customer,
                              Collected = order.Collected,
                              PromoCode = code.Code,
                              TotalCost = order.TotalCost
                          };

            return _orderBEANs.ToList();
        }

        public Order GetOrder(int id)
        {
            IQueryable<Order> _order;

            _order = from order in _context.Order
                     where order.Id == id
                     select order;

            return _order.ToList().First();
        }

        public OrderBEAN GetBEANOrder(int id)
        {
            IQueryable<OrderBEAN> _orderBEAN;

            _orderBEAN = from order in _context.Order
                         from code in _context.PromoCode
                         where order.Id == id
                         && order.PromoCode == code.Code
                         select new OrderBEAN
                         {
                             Id = order.Id,
                             OrderDate = order.OrderDate,
                             CollectFrom = order.CollectFrom,
                             CollectBy = order.CollectBy,
                             Customer = order.Customer,
                             Collected = order.Collected,
                             PromoCode = code.Code,
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

            Order _order = GetOrder(order.Id);

            _order.OrderDate = order.OrderDate;
            _order.CollectFrom = order.CollectFrom;
            _order.CollectBy = order.CollectBy;
            _order.Customer = order.Customer;
            _order.Collected = order.Collected;
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
