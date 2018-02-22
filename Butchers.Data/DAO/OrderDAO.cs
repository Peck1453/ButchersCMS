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

        public IList<PromoCodeBEAN> GetPromoCodes()
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

        public PromoCodeBEAN GetPromoCodeBEAN(string id)
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
        
        public PromoCode GetPromoCode(string Id)
        {
            IQueryable<PromoCode> _code;

            _code = from pcode
                    in _context.PromoCode
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
        public IList<CartItemBEAN> GetCartItems()
        {
            IQueryable<CartItemBEAN> _cartItemBEANs = from cart in _context.CartItem
                                                      from prod in _context.Product
                                                      where cart.ProductItem == prod.Id
                                                      select new CartItemBEAN
                                                      {
                                                          Id = cart.Id,
                                                          ProductItem = prod.Name,
                                                          Quantity = cart.Quantity,
                                                          DateAdded = cart.DateAdded
                                                      };

            return _cartItemBEANs.ToList();
        }

        public CartItemBEAN GetProductItem(int id)
        {
            IQueryable<CartItemBEAN> _cartItemBEANs = from cart in _context.CartItem
                                                       from prod in _context.Product
                                                       where cart.ProductItem == prod.Id
                                                       select new CartItemBEAN
                                                       {
                                                           Id = cart.Id,
                                                           ProductItem = prod.Name,
                                                           Quantity = cart.Quantity,
                                                           DateAdded = cart.DateAdded

                                                       };
            return  _cartItemBEANs.ToList().First();



        }

        public void AddCartItem(CartItem cartItem)
        {
            _context.CartItem.Add(cartItem);
            _context.SaveChanges();
        }

        public void EditCartItem(CartItem cartItem)
        {
            CartItem Myeditcart = Geteditcart(CartItem.Id)

            myeditcart.

        }

        public void DeleteCartItem(CartItem cartItem)
        {
            throw new NotImplementedException();
        }
    }

}
