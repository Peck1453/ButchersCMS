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
        private bool PromocodeCheck(int id)
        {

            IQueryable<int> PromoList = from Promos in _context.PromoCode
                                        select Promos.Code;

            if (PromoList.ToList<int>().Contains(id))
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

    }

}
