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
        IList<PromoCode> GetPromoCodes();
        PromoCode GetPromoCode(string id);
        void AddPromoCode(PromoCode code);
        void EditPromoCode(PromoCode code);
        void DeletePromoCode(PromoCode code);

        //PromoCode BEANs

        IList<PromoCodeBEAN> GetBEANPromoCodes();
        PromoCodeBEAN GetBEANPromoCode(string id);

        //Promocode APIs
        bool AddAPIPromocode(PromoCode code);
        bool DeleteAPIPromoCode(PromoCode code);

        // Cart Items
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
        IList<Cart> GetCarts();
        Cart GetCart(int id);
        void AddCart(Cart cart);
        void EditCart(Cart cart);
        void DeleteCart(Cart cart);

        // CartItem BEANs
        IList<CartBEAN> GetBEANCarts();
        CartBEAN GetBEANCart(int id);

        // CartAPIs
        bool AddAPICart(Cart cart);
        bool DeleteAPICart(Cart cart);

        // Orders
        //IList<Order> GetOrders();
        //IList<OrderBEAN> GetBEANOrders();
        //Order GetOrder(int id);
        //OrderBEAN GetBEANOrder(int id);
        //void AddOrder(Order order);
        //void EditOrder(Order order);
        //void DeleteOrder(Order order);
    }
}
