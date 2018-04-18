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

        // Gets a standard list of promo codes
        public IList<PromoCode> GetPromoCodes()
        {
            IQueryable<PromoCode> _promoCodes;

            _promoCodes = from code in _context.PromoCode
                          select code;

            return _promoCodes.ToList();
        }

        // Counts the number of promo codes
        public int CountPromoCodes()
        {
            IList<PromoCode> _promoCodes = GetPromoCodes();

            return _promoCodes.Count();
        }

        // Gets an individual promo code from the id (code)
        public PromoCode GetPromoCode(string Id)
        {
            IQueryable<PromoCode> _code;

            _code = from pcode in _context.PromoCode
                    where pcode.Code == Id
                    select pcode;

            return _code.ToList().First();
        }

        // Adds a new promo code
        public void AddPromoCode(PromoCode code)
        {
            _context.PromoCode.Add(code);
            _context.SaveChanges();
        }

        // edits a selected (by code) promo code
        public void EditPromoCode(PromoCode code)
        {

            PromoCode myCode = GetPromoCode(code.Code);

            myCode.Code = code.Code; // ** This could be removed as the field is read only
            myCode.Discount = code.Discount;
            myCode.ValidUntil = code.ValidUntil;

            _context.SaveChanges();
        }

        // displays a list of promo codes which have attribute decoration for labels and validation
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

        // displays an individual promo code with attribute decoration for labels and validation
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

        // Checks to see whether a promo code exists
        // This is used for applying a discount to an order
        private bool PromocodeCheck(string id)
        {

            IQueryable<string> PromoList = from Promos in _context.PromoCode
                                           select Promos.Code;

            if (PromoList.ToList().Contains(id))
            {
                return true; // If true, a discount can be applied
            }
            else
            {
                return false; // If false, a discount cannot be applied
            }
        }
        
        // Gets a list of all cart items which can be used by the count 
        public IList<CartItem> GetCartItems()
        {
            IQueryable<CartItem> _cartItems = from cart in _context.CartItem
                                              select cart;

            return _cartItems.ToList();
        }

        // displays a list of product items in the current cart
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
                                                      ProductItem = prod.Name, // Finds the product name from the product Id
                                                      ProductItemId = cart.ProductItemId,
                                                      Quantity = cart.Quantity,
                                                      CartId = cart.CartId,
                                                      ItemCostSubtotal = prodItem.Cost // Identifies an item cost
                                                  };

            return _cartItems.ToList();
        }

        // This selects an individual product item which has been added to the cart
        // This is used when deleting a cart item
        public CartItem GetCartItem(int id)
        {
            IQueryable<CartItem> _cart;

            _cart = from cart in _context.CartItem
                    where cart.CartItemId == id // Selects items matching this (current cart) id
                    select cart;

            return _cart.ToList().First();
        }

        // Adds an item to the current cart
        public void AddCartItem(CartItem cartItem)
        {
            _context.CartItem.Add(cartItem);
            _context.SaveChanges();
        }

        // Removes a product item from the cart
        public void DeleteCartItem(CartItem cartItem)
        {
            CartItem myCartItem = GetCartItem(cartItem.CartItemId);

            _context.CartItem.Remove(cartItem);
            _context.SaveChanges();
        }

        // Gets a customised viewmodel list of product items in the cart 
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
                                                          ProductItem = prod.Name, // Finds the product name from the product id
                                                          ProductItemId = cartItem.ProductItemId,
                                                          Quantity = cartItem.Quantity,
                                                          CartId = cartItem.CartId,
                                                          ItemCostSubtotal = prodItem.Cost // Gets the productItem cost
                                                      };

            return _cartItemBEANs.ToList();
        }

        // Gets a single cart item from the viewmodel
        public CartItemBEAN GetBEANCartItem(int id)
        {
            IQueryable<CartItemBEAN> _cartBEAN;
            _cartBEAN = from cartItem in _context.CartItem
                        from prod in _context.Product
                        from prodItem in _context.ProductItem
                        where cartItem.CartItemId == id // Where the id matches the selected item's cart item id
                        && cartItem.ProductItemId == prodItem.ProductItemId
                        && prod.ProductId == prodItem.ProductId
                        select new CartItemBEAN
                        {
                            CartItemId = cartItem.CartItemId,
                            ProductItem = prod.Name, // Finds the product name from the product id
                            ProductItemId = cartItem.ProductItemId,
                            Quantity = cartItem.Quantity,
                            CartId = cartItem.CartId,
                            ItemCostSubtotal = prodItem.Cost // Gets the cost from the product item information
                        };

            return _cartBEAN.ToList().First();
        }

        // Gets a list of all carts
        public IList<Cart> GetCarts()
        {
            IQueryable<Cart> _cart = from cart in _context.Cart
                                              select cart;

            return _cart.ToList();
        }
        
        // Counts all carts
        public int CountCarts()
        {
            IList<Cart> _carts = GetCarts(); // Uses the get all carts method

            return _carts.Count();
        }

        // Gets an individual cart
        public Cart GetCart(int id)
        {
            IQueryable<Cart> _cart;

            _cart = from cart in _context.Cart
                    where cart.CartId == id
                    select cart;

            return _cart.ToList().First();
        }

        // Adds a cart and returns its id so it can immediately be assigned to a session
        public int AddCartAndReturnId(Cart cart)
        {
            _context.Cart.Add(cart);
            _context.SaveChanges();

            return cart.CartId; // Returns the id to assign to a session
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

        // Gets a single cart from the view model
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

        // Gets a list of all orders
        public IList<Order> GetOrders()
        {

            IQueryable<Order> _orders = from ord in _context.Order
                                        select ord;

            return _orders.ToList();
        }

        // Counts the number of orders which have been made
        public int CountOrders()
        {
            IList<Order> _orders = GetOrders(); // Uses the get orders method to generate a list

            return _orders.Count();
        }

        // Gets a single order
        public Order GetOrder(int id)
        {
            IQueryable<Order> _order;

            _order = from order in _context.Order
                     where order.OrderNo == id // Selects the order from the id (order no)

                     select order;
            return _order.ToList().First();
        }

        // Adds and order and returns an id which can be used to generate order details.
        public int AddOrderAndReturnId(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();

            return order.OrderNo;
        }

        // Gets a list of orders using the BEAN/ViewModel to show custom information
        public IList<OrderBEAN> GetBEANOrders()
        {
            IQueryable<OrderBEAN> _orderBEANs = from ord in _context.Order
                                                from dets in _context.OrderDetails
                                                from user in _context.AspNetUsers
                                                where ord.OrderNo == dets.OrderNo
                                                && ord.CustomerNo == user.Id // Matches the customer number to the user id
                                                orderby ord.OrderNo descending
                                                select new OrderBEAN
                                                {
                                                    OrderNo = ord.OrderNo,
                                                    OrderDate = ord.OrderDate,
                                                    CustomerNo = user.UserName, // Show the username instead of the user id
                                                    PromoCode = ord.PromoCode,
                                                    TotalCost = ord.TotalCost,
                                                    CartId = ord.CartId,
                                                    TotalCostAfterDiscount = ord.TotalCostAfterDiscount,
                                                    AmountSaved = (ord.TotalCost - ord.TotalCostAfterDiscount), // Calculates new amount

                                                    // Displays the Order Details with the order as it takes the same Id (order no)
                                                    CollectFrom = dets.CollectFrom,
                                                    CollectBy = dets.CollectBy,
                                                    Collected = dets.Collected
                                                };
            return _orderBEANs.ToList();
        }

        // Finds a list of orders matching the logged in customer only
        // This is used to stop other non-authenticated users from viewing other customer information
        public IList<OrderBEAN> GetBEANCustomerOrders(string uid)
        {
            IQueryable<OrderBEAN> _orderBEANs = from ord in _context.Order
                                                from dets in _context.OrderDetails
                                                from user in _context.AspNetUsers
                                                where ord.CustomerNo == uid // Checks that the customer number matches the logged in user id
                                                && ord.OrderNo == dets.OrderNo
                                                && ord.CustomerNo == user.Id // Matches the customer number to the user id
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
                                                    AmountSaved = (ord.TotalCost - ord.TotalCostAfterDiscount), // Calculates new amount

                                                    // Displays the Order Details with the order as it takes the same Id (order no)
                                                    CollectFrom = dets.CollectFrom,
                                                    CollectBy = dets.CollectBy,
                                                    Collected = dets.Collected
                                                };
            return _orderBEANs.ToList();
        }

        // Gets information about a single order and order details in the same view model
        public OrderBEAN GetBEANOrder(int id)
        {
            {
                IQueryable<OrderBEAN> _orderBEANS = from ord in _context.Order
                                                    from dets in _context.OrderDetails
                                                    from user in _context.AspNetUsers
                                                    where ord.OrderNo == id
                                                    && dets.OrderNo == ord.OrderNo
                                                    && user.Id == ord.CustomerNo // Matches the customer number to the user id
                                                    select new OrderBEAN
                                                    {
                                                        OrderNo = ord.OrderNo,
                                                        OrderDate = ord.OrderDate,
                                                        CustomerNo = user.UserName,
                                                        PromoCode = ord.PromoCode,
                                                        TotalCost = ord.TotalCost,
                                                        CartId = ord.CartId,
                                                        TotalCostAfterDiscount = ord.TotalCostAfterDiscount,
                                                        AmountSaved = (ord.TotalCost - ord.TotalCostAfterDiscount), // Calculates new amount

                                                        // Displays the Order Details with the order as it takes the same Id (order no)
                                                        CollectFrom = dets.CollectFrom,
                                                        CollectBy = dets.CollectBy,
                                                        Collected = dets.Collected
                                                    };

                return _orderBEANS.ToList().First();
            }
        }

        // Gets the order details for a specific order using its id (order no)
        public OrderDetails GetOrderDetail(int id)
        {
            IQueryable<OrderDetails> _detail;

            _detail = from detail in _context.OrderDetails
                      where detail.OrderDetailsId == id // Finds the order using the id (order no)
                      select detail;

            return _detail.ToList().First();
        }

        // Gets the order details for a selected order (using order number as id) to toggle the status
        public OrderDetails ToggleCollected(int id)
        {
            IQueryable<OrderDetails> _detail;

            _detail = from detail in _context.OrderDetails
                      where detail.OrderNo == id // Selects where the id (order number) matches that selected
                      select detail;

            return _detail.ToList().First();
        }

        // Adds order details for an order
        public void AddOrderDetails(OrderDetails details)
        {
            _context.OrderDetails.Add(details);
            _context.SaveChanges();
        }

        // Edits order details for a selected order
        public void EditOrderDetails(OrderDetails details)
        {

            OrderDetails _details = GetOrderDetail(details.OrderDetailsId);

            _details.OrderNo = details.OrderNo;
            _details.CollectFrom = details.CollectFrom;
            _details.CollectBy = details.CollectBy;
            _details.Collected = details.Collected;

            // ** This could be refined as order details aren't edited in full. Only the collected status is edited.

            _context.SaveChanges();
        }

        // Gets the details of a selected order 
        public OrderDetailsBEAN GetBEANOrderDetail(int id)
        {
            IQueryable<OrderDetailsBEAN> _detailBEAN;

            _detailBEAN = from details in _context.OrderDetails
                        where details.OrderDetailsId == id // selects the order details from the id (order no)
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

        // Counts the amount of orders which have been marked as collected
        public int countOrdersCollected()
        {
            IQueryable<OrderDetails> _countcollected;

            _countcollected = from details in _context.OrderDetails
                              where details.Collected == true
                              select details;

            return _countcollected.Count();


        }

        // Counts the number of orders which have been cancelled (or not collected)
        public int countOrdersCancelled()
        {
            IQueryable<OrderDetails> _countcancelled;

            _countcancelled = from details in _context.OrderDetails
                              where details.CollectBy < DateTime.Now && details.Collected == false
                              select details;

            return _countcancelled.Count();

        }


        // Calculates the cart cost from the items in the cart
        public decimal GetCartCost(int cartId)
        {
            IList<CartItemBEAN> items = GetCartItemsByCartId(cartId); // Gets a list of the items with the session's cart id
            
            decimal total = decimal.Parse("0.00"); // Sets total as £0.00

            // Loops through all items in the cart to calculate a running total
            foreach (var item in items)
            {
                total = total + (item.ItemCostSubtotal * item.Quantity); // Multiplies the number of items by the cost and adds to the running total
            }
            
            return total; // Returns the cost
        }

        // Calculates the cost once the discount has been applied
        public decimal GetCostAfterDiscount(decimal currentTotal, string promoCode)
        {
            if (promoCode != null && promoCode != "") // Checks that a promo code has been entered
            {
                IList<PromoCode> promoCodes = GetPromoCodes(); // Gets the list of all promo codes
                PromoCode selected = promoCodes.FirstOrDefault(code =>
                {
                    return code.Code.ToLower() == promoCode.ToLower(); // Selects the matching promo code
                });

                if (selected != null && selected.ValidUntil > DateTime.Now) // Checks whether the promo code is valid
                {
                    decimal discount = (currentTotal / 100) * selected.Discount; // Calculates the discount from the amount and the percentage discount

                    return currentTotal - discount; // Take away the discount from the total
                }
                else
                {
                    return -1; // Returns an error message if the promo code is invalid
                }
            }
            else
            {
                return currentTotal; // If promo code has not been entered, return the total
            }
        }
    }
}
