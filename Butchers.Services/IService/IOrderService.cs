using Butchers.Data;
using Butchers.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Services.IService
{
    public interface IOrderService
    {
        //PromoCode
        IList<PromoCodeBEAN> GetPromoCodes();
        PromoCodeBEAN GetPromoCodeBEAN(string id);
        PromoCode GetPromoCode(string id);
        void AddPromoCode(PromoCode code);
        void EditPromoCode(PromoCode code);
        void DeletePromoCode(PromoCode code);

        //// Cart Items
        IList<CartItemBEAN> GetCartItems();

        CartItem GetProductItem(int id);

        void AddCartItem(CartItem cartItem); 

        void EditCartItem(CartItem cartItem);

        void DeleteCartItem(CartItem cartItem);


        
    }
}
