using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Butchers.Data;
using Butchers.Data.BEANS;

namespace Butchers.Data.IDAO
{
    public interface IOrderDAO
    {
        // Product Code
        IList<PromoCodeBEAN> GetPromoCodes();
        PromoCodeBEAN GetPromoCodeBEAN(string id);
        PromoCode GetPromoCode(string id);
        void AddPromoCode(PromoCode code);
        void EditPromoCode(PromoCode code);
        void DeletePromoCode(PromoCode code);

        //// Cart Items
        IList<CartItemBEAN> GetCartItems();

        CartItemBEAN GetProductItemBEAN(int id); 

        CartItemBEAN GetProductItem(int id);

        void AddCartItem(CartItem cartItem);

        void EditCartItem(CartItem cartItem);

        void DeleteCartItem(CartItem cartItem);
        
        
        //CartItem GetProductItem(int id);
        //void AddCartItem(CartItem cartItem);
        //void EditCartItem(CartItem cartItem);
        //void DeleteCartItem(CartItem cartItem);
    }
}
