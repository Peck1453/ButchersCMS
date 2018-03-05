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
        IList<PromoCode> GetPromoCodes();
        IList<PromoCodeBEAN> GetBEANPromoCodes();
        PromoCode GetPromoCode(string id);
        PromoCodeBEAN GetBEANPromoCode(string id);
        void AddPromoCode(PromoCode code);
        void EditPromoCode(PromoCode code);
        void DeletePromoCode(PromoCode code);

        // Cart Items
        IList<CartItem> GetCartItems();
        IList<CartItemBEAN> GetBEANCartItems();
        CartItem GetCartItem(int id);
        CartItemBEAN GetBEANCartItem(int id);
        void AddCartItem(CartItem cartItem);
        void EditCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);

        // Order
        IList<Order> GetOrders();
        IList<OrderBEAN> GetBEANOrders();
        Order GetOrder(int id);
        OrderBEAN GetBEANOrder(int id);
        void AddOrder(Order order);
        void EditOrder(Order order);
        void DeleteOrder(Order order);
    }
}
