using Butchers.Data.BEANS;
using Butchers.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public int CountPromoCodes()
        {
            IList<PromoCode> _promoCodes = GetPromoCodes();

            return _promoCodes.Count();
        }


        public PromoCode GetPromoCode(string Id)
        {
            IQueryable<PromoCode> _code;

            _code = from pcode in _context.PromoCode
                    where pcode.Code == Id
                    select pcode;

            return _code.ToList().First();
        }

        public void AddPromoCode(PromoCode code)
        {
            _context.PromoCode.Add(code);
            _context.SaveChanges();
        }

        public void EditPromoCode(PromoCode code)
        {

            PromoCode myCode = GetPromoCode(code.Code);

            myCode.Code = code.Code;
            myCode.Discount = code.Discount;
            myCode.ValidUntil = code.ValidUntil;

            _context.SaveChanges();
        }

        // PromoCode BEANs
        public IList<PromoCodeBEAN> GetBEANPromoCodes()
        {
            IQueryable<PromoCodeBEAN> _promoCodeBEANs;
            _promoCodeBEANs = from code in _context.PromoCode
                              select new PromoCodeBEAN
                              {
                                  Code = code.Code,
                                  Discount = code.Discount,
                                  ValidUntil = code.ValidUntil,
                                  DisplayValidUntil = code.ValidUntil
                              };

            return _promoCodeBEANs.ToList();
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
                            ValidUntil = pcode.ValidUntil,
                            DisplayValidUntil = pcode.ValidUntil
                        };

            return _codeBEAN.ToList().First();
        }

        //Promocode APIs
        private bool PromocodeCheck(string id)
        {

            IQueryable<string> PromoList = from Promos in _context.PromoCode
                                           select Promos.Code;

            if (PromoList.ToList().Contains(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddAPIPromocode(PromoCode code)
        {
            try
            {
                _context.PromoCode.Add(code);
                _context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \" {0} \" in state \"{1}\" has the following validation errors:",
                    eve.Entry.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error:\"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                return false;
                throw;
            }
        }

        public bool EditAPIPromocode(PromoCode code)
        {
            if (PromocodeCheck(code.Code) == true)
            {
                PromoCode myCode = GetPromoCode(code.Code);

                myCode.Code = code.Code;
                myCode.Discount = code.Discount;
                myCode.ValidUntil = code.ValidUntil;

                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        // Cart Item
        public IList<CartItem> GetCartItems()
        {
            IQueryable<CartItem> _cartItems = from cart in _context.CartItem
                                              select cart;

            return _cartItems.ToList();
        }

        public IList<CartItemBEAN> GetCartItemsByCartId(int cartId)
        {
            IQueryable<CartItemBEAN> _cartItems = from cart in _context.CartItem
                                                  from prodItem in _context.ProductItem
                                                  from prod in _context.Product
                                                  where cart.CartId == cartId
                                                  && cart.ProductItemId == prodItem.ProductItemId
                                                  && prodItem.ProductId == prod.ProductId
                                                  select new CartItemBEAN
                                                  {
                                                      CartItemId = cart.CartItemId,
                                                      ProductItem = prod.Name,
                                                      ProductItemId = prodItem.ProductItemId,
                                                      Quantity = cart.Quantity,
                                                      CartId = cart.CartId,
                                                      ItemCostSubtotal = prodItem.Cost
                                                  };

            return _cartItems.ToList();
        }

        public CartItem GetCartItem(int id)
        {
            IQueryable<CartItem> _cart;

            _cart = from cart in _context.CartItem
                    where cart.CartItemId == id
                    select cart;

            return _cart.ToList().First();
        }

        public void AddCartItem(CartItem cartItem)
        {
            _context.CartItem.Add(cartItem);
            _context.SaveChanges();
        }

        public void EditCartItem(CartItem cartItem)
        {
            CartItem myCartItem = GetCartItem(cartItem.CartItemId);

            myCartItem.ProductItemId = cartItem.ProductItemId;
            myCartItem.CartId = cartItem.CartId;
            myCartItem.Quantity = cartItem.Quantity;
            myCartItem.ItemCostSubtotal = cartItem.ItemCostSubtotal;

            _context.SaveChanges();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            CartItem myCartItem = GetCartItem(cartItem.CartItemId);

            _context.CartItem.Remove(cartItem);
            _context.SaveChanges();
        }

        // CartItem BEANs
        public IList<CartItemBEAN> GetBEANCartItems()
        {
            IQueryable<CartItemBEAN> _cartItemBEANs = from cartItem in _context.CartItem
                                                      from prodItem in _context.ProductItem
                                                      from prod in _context.Product
                                                      where cartItem.ProductItemId == prodItem.ProductItemId
                                                      && prodItem.ProductId == prod.ProductId
                                                      select new CartItemBEAN
                                                      {
                                                          CartItemId = cartItem.CartItemId,
                                                          ProductItem = prod.Name,
                                                          ProductItemId = prodItem.ProductItemId,
                                                          Quantity = cartItem.Quantity,
                                                          CartId = cartItem.CartId,
                                                          ItemCostSubtotal = prodItem.Cost
                                                      };

            return _cartItemBEANs.ToList();
        }

        public CartItemBEAN GetBEANCartItem(int id)
        {
            IQueryable<CartItemBEAN> _cartBEAN;
            _cartBEAN = from cartItem in _context.CartItem
                        from prod in _context.Product
                        from prodItem in _context.ProductItem
                        where cartItem.CartItemId == id
                        && cartItem.ProductItemId == prodItem.ProductItemId
                        && prod.ProductId == prodItem.ProductId
                        select new CartItemBEAN
                        {
                            CartItemId = cartItem.CartItemId,
                            ProductItem = prod.Name,
                            ProductItemId = prodItem.ProductItemId,
                            Quantity = cartItem.Quantity,
                            CartId = cartItem.CartId,
                            ItemCostSubtotal = prodItem.Cost
                        };

            return _cartBEAN.ToList().First();
        }
        
        private bool CartItemCheck(int id)
        {
            IQueryable<int> cartItemList = from cartItems in _context.CartItem
                                           select cartItems.CartItemId;
            if (cartItemList.ToList().Contains(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Cart
        public IList<Cart> GetCarts()
        {
            IQueryable<Cart> _cart = from cart in _context.Cart
                                              select cart;

            return _cart.ToList();
        }
        
        public int CountCarts()
        {
            IList<Cart> _carts = GetCarts();

            return _carts.Count();
        }

        public Cart GetCart(int id)
        {
            IQueryable<Cart> _cart;

            _cart = from cart in _context.Cart
                    where cart.CartId == id
                    select cart;

            return _cart.ToList().First();
        }

        //public void AddCart(Cart cart)
        //{
        //    _context.Cart.Add(cart);
        //    _context.SaveChanges();
        //}

        public int AddCartAndReturnId(Cart cart)
        {
            _context.Cart.Add(cart);
            _context.SaveChanges();

            return cart.CartId;
        }

        // Cart BEANs
        public IList<CartBEAN> GetBEANCarts()
        {
            IQueryable<CartBEAN> _cartBEANs = from cart in _context.Cart
                                                  select new CartBEAN
                                                  {
                                                      CartId = cart.CartId
                                                  };

            return _cartBEANs.ToList();
        }

        public CartBEAN GetBEANCart(int id)
        {
            IQueryable<CartBEAN> _cartBEAN;
            _cartBEAN = from cart in _context.Cart
                        where cart.CartId == id
                        select new CartBEAN
                        {
                            CartId = cart.CartId
                        };

            return _cartBEAN.ToList().First();
        }

        //Cart API
        private bool CartCheck(int id)
        {
            IQueryable<int> cartList = from cart_item in _context.Cart
                                       select cart_item.CartId;

            if (cartList.ToList().Contains(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Orders
        public IList<Order> GetOrders()
        {

            IQueryable<Order> _orders = from ord in _context.Order
                                        select ord;

            return _orders.ToList();
        }

        public int CountOrders()
        {
            IList<Order> _orders = GetOrders();

            return _orders.Count();
        }

        public Order GetOrder(int id)
        {
            IQueryable<Order> _order;

            _order = from order in _context.Order
                     where order.OrderNo == id

                     select order;
            return _order.ToList().First();
        }

        public int AddOrderAndReturnId(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();

            return order.OrderNo;
        }

        //OrderBEAN
        public IList<OrderBEAN> GetBEANOrders()
        {
            IQueryable<OrderBEAN> _orderBEANs = from ord in _context.Order
                                                from dets in _context.OrderDetails
                                                from user in _context.AspNetUsers
                                                where ord.OrderNo == dets.OrderNo
                                                && ord.CustomerNo == user.Id
                                                orderby ord.OrderNo descending
                                                select new OrderBEAN
                                                {
                                                    OrderNo = ord.OrderNo,
                                                    OrderDate = ord.OrderDate,
                                                    CustomerNo = user.UserName,
                                                    PromoCode = ord.PromoCode,
                                                    TotalCost = ord.TotalCost,
                                                    CartId = ord.CartId,
                                                    TotalCostAfterDiscount = ord.TotalCostAfterDiscount,

                                                    // Calculates new amount
                                                    AmountSaved = (ord.TotalCost - ord.TotalCostAfterDiscount),

                                                    //Order Details
                                                    CollectFrom = dets.CollectFrom,
                                                    CollectBy = dets.CollectBy,
                                                    Collected = dets.Collected
                                                };
            return _orderBEANs.ToList();
        }

        public IList<OrderBEAN> GetBEANCustomerOrders(string uid)
        {
            IQueryable<OrderBEAN> _orderBEANs = from ord in _context.Order
                                                from dets in _context.OrderDetails
                                                from user in _context.AspNetUsers
                                                where ord.CustomerNo == uid
                                                && ord.OrderNo == dets.OrderNo
                                                && ord.CustomerNo == user.Id
                                                orderby ord.OrderNo descending
                                                select new OrderBEAN
                                                {
                                                    OrderNo = ord.OrderNo,
                                                    OrderDate = ord.OrderDate,
                                                    CustomerNo = user.UserName,
                                                    PromoCode = ord.PromoCode,
                                                    TotalCost = ord.TotalCost,
                                                    CartId = ord.CartId,
                                                    TotalCostAfterDiscount = ord.TotalCostAfterDiscount,

                                                    // Calculates new amount
                                                    AmountSaved = (ord.TotalCost - ord.TotalCostAfterDiscount),

                                                    //Order Details
                                                    CollectFrom = dets.CollectFrom,
                                                    CollectBy = dets.CollectBy,
                                                    Collected = dets.Collected
                                                };
            return _orderBEANs.ToList();
        }

        public OrderBEAN GetBEANOrder(int id)
        {
            {
                IQueryable<OrderBEAN> _orderBEANS = from ord in _context.Order
                                                    from dets in _context.OrderDetails
                                                    from user in _context.AspNetUsers
                                                    where ord.OrderNo == id
                                                    && dets.OrderNo == ord.OrderNo
                                                    && user.Id == ord.CustomerNo
                                                    select new OrderBEAN
                                                    {
                                                        OrderNo = ord.OrderNo,
                                                        OrderDate = ord.OrderDate,
                                                        CustomerNo = user.UserName,
                                                        PromoCode = ord.PromoCode,
                                                        TotalCost = ord.TotalCost,
                                                        CartId = ord.CartId,
                                                        TotalCostAfterDiscount = ord.TotalCostAfterDiscount,

                                                        // Calculates new amount
                                                        AmountSaved = (ord.TotalCost - ord.TotalCostAfterDiscount),

                                                        //Order Details
                                                        CollectFrom = dets.CollectFrom,
                                                        CollectBy = dets.CollectBy,
                                                        Collected = dets.Collected
                                                    };
                return _orderBEANS.ToList().First();
            }
        }

        //OrderAPI
        private bool OrderCheck(int id)
        {
            IQueryable<int> orderList = from orders in _context.Order
                                          select orders.OrderNo;
            if (orderList.ToList().Contains(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Order Details
        public IList<OrderDetails> GetOrderDetails()
        {
            IQueryable<OrderDetails> _orderDetails;

            _orderDetails = from details in _context.OrderDetails
                            select details;

            return _orderDetails.ToList();
        }

        public OrderDetails GetOrderDetail(int id)
        {
            IQueryable<OrderDetails> _detail;

            _detail = from detail in _context.OrderDetails
                      where detail.OrderDetailsId == id
                      select detail;

            return _detail.ToList().First();
        }

        public OrderDetails ToggleCollected(int id)
        {
            IQueryable<OrderDetails> _detail;

            _detail = from detail in _context.OrderDetails
                      where detail.OrderNo == id
                      select detail;

            return _detail.ToList().First();
        }

        public void AddOrderDetails(OrderDetails details)
        {
            _context.OrderDetails.Add(details);
            _context.SaveChanges();
        }

        public void EditOrderDetails(OrderDetails details)
        {

            OrderDetails _details = GetOrderDetail(details.OrderDetailsId);

            _details.OrderNo = details.OrderNo;
            _details.CollectFrom = details.CollectFrom;
            _details.CollectBy = details.CollectBy;
            _details.Collected = details.Collected;

            _context.SaveChanges();
        }

        // OrderDetails BEANs
        public IList<OrderDetailsBEAN> GetBEANOrderDetails()
        {
            IQueryable<OrderDetailsBEAN> _orderDetailsBEANs;

            _orderDetailsBEANs = from details in _context.OrderDetails
                              select new OrderDetailsBEAN
                              {
                                  OrderDetailsId = details.OrderDetailsId,
                                  OrderNo = details.OrderNo,
                                  CollectFrom = details.CollectFrom,
                                  CollectBy = details.CollectBy,
                                  Collected = details.Collected
                              };

            return _orderDetailsBEANs.ToList();
        }

        public OrderDetailsBEAN GetBEANOrderDetail(int id)
        {
            IQueryable<OrderDetailsBEAN> _detailBEAN;

            _detailBEAN = from details in _context.OrderDetails
                        where details.OrderDetailsId == id
                        select new OrderDetailsBEAN
                        {
                            OrderDetailsId = details.OrderDetailsId,
                            OrderNo = details.OrderNo,
                            CollectFrom = details.CollectFrom,
                            CollectBy = details.CollectBy,
                            Collected = details.Collected
                        };

            return _detailBEAN.ToList().First();
        }
        
        private bool OrderDetailsCheck(int id)
        {

            IQueryable<int> orderDetailsList = from orderDetails in _context.OrderDetails
                                               select orderDetails.OrderDetailsId;

            if (orderDetailsList.ToList().Contains(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Order Detail count cancelled vs collected

        public int countOrdersCollected()
        {
            IQueryable<OrderDetails> _countcollected;

            _countcollected = from details in _context.OrderDetails
                              where details.Collected == true
                              select details;

            return _countcollected.Count();


        }

        public int countOrdersCancelled()
        {
            IQueryable<OrderDetails> _countcancelled;

            _countcancelled = from details in _context.OrderDetails
                              where details.CollectBy < DateTime.Now && details.Collected == false
                              select details;

            return _countcancelled.Count();

        }


        //Calculations
        public decimal GetCartCost(int cartId)
        {
            // Gets a list of the items with the session's cart id
            IList<CartItemBEAN> items = GetCartItemsByCartId(cartId);

            // Sets total as £0.00
            decimal total = decimal.Parse("0.00");

            // Loops through all items in the cart to calculate a running total
            foreach (var item in items)
            {
                total = total + (item.ItemCostSubtotal * item.Quantity);
            }

            // Returns the cost
            return total;
        }

        public decimal GetCostAfterDiscount(decimal currentTotal, string promoCode)
        {
            if (promoCode != null && promoCode != "")
            {
                IList<PromoCode> promoCodes = GetPromoCodes();
                PromoCode selected = promoCodes.FirstOrDefault(code =>
                {
                    return code.Code.ToLower() == promoCode.ToLower();
                });

                if (selected != null && selected.ValidUntil > DateTime.Now)
                {
                    decimal discount = (currentTotal / 100) * selected.Discount;

                    return currentTotal - discount;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return currentTotal;
            }
        }
    }
}
