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
        // Promo Code
        IList<PromoCode> GetPromoCodes();
        PromoCode GetPromoCode(string id);
        void AddPromoCode(PromoCode code);
        void EditPromoCode(PromoCode code);
        void DeletePromoCode(PromoCode code);

        //Promocode BEANS 
        IList<PromoCodeBEAN> GetBEANPromoCodes();
        PromoCodeBEAN GetBEANPromoCode(string id);

        //Promocode APIS
        bool AddAPIPromocode(PromoCode code);
        bool DeleteAPIPromocode(PromoCode code);

        // CartItems
        IList<CartItem> GetCartItems();
        CartItem GetCartItem(int id);
        void AddCartItem(CartItem cartItem);
        void EditCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);

        // CartItem BEANs
        IList<CartItemBEAN> GetBEANCartItems();
        CartItemBEAN GetBEANCartItem(int id);

        // CartItem APIs
        bool AddAPICartItem(CartItem cartItem);
        bool DeleteAPICartItem(CartItem cartItem);

        //Cart
        IList<Cart> GetCart();
        Cart GetCartDeatil(int id);

        //Cart Bean
        IList<CartBEAN> GetBEANCart();
        CartBEAN GetBEANCartdetail(int id);

        // CartAPIs
        bool AddAPICart(Cart cart);
        bool DeleteAPICart(Cart cart);

        // Order
        //IList<Order> GetOrders();
        //IList<OrderBEAN> GetBEANOrders();
        //Order GetOrder(int id);
        //OrderBEAN GetBEANOrder(int id);
        //void AddOrder(Order order);
        //void EditOrder(Order order);
        //void DeleteOrder(Order order);
    }
}
