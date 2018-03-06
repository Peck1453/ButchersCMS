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

        public void EditPromoCode(PromoCode pcode)
        {

            PromoCode _code = GetPromoCode(pcode.Code);

            _code.Code = pcode.Code;
            _code.Discount = pcode.Discount;
            _code.ValidUntil = pcode.ValidUntil;

            _context.SaveChanges();
        }
        public void DeletePromoCode(PromoCode code)
        {
            _context.PromoCode.Remove(code);
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
                                  ValidUntil = code.ValidUntil
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
                            ValidUntil = pcode.ValidUntil
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

        public bool DeleteAPIPromocode(PromoCode code)
        {
            if (PromocodeCheck(code.Code) == true)
            {

                _context.PromoCode.Remove(code);
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

        // Cart BEANs
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

        // CartItem APIs
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

        public bool AddAPICartItem(CartItem cartItem)
        {
            try
            {
                _context.CartItem.Add(cartItem);
                _context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{ 0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
            }
            return true;
        }

        public bool DeleteAPICartItem(CartItem cartItem)
        {
            if (CartItemCheck(cartItem.CartItemId) == true)
            {
                _context.CartItem.Remove(cartItem);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //Cart
        public IList<Cart> GetCart()
        {
            IQueryable<Cart> _cart = from cart in _context.Cart
                                              select cart;

            return _cart.ToList();
        }

        public Cart GetCartDetail(int id)
        {
            IQueryable<Cart> _cart;

            _cart = from cart in _context.Cart
                    where cart.CartId == id
                    select cart;

            return _cart.ToList().First();

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

        public bool AddAPICart(Cart cart)
        {
            try
            {
                _context.Cart.Add(cart);
                _context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{ 0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                return false;
                throw;
            }
        }

       
        public bool DeleteAPICart(Cart cart)
        {
            if (CartCheck(cart.CartId) == true)
            {
                _context.Cart.Remove(cart);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
