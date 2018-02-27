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

        // Cart Items
        IList<CartItem> GetCartItems();
        IList<CartItemBEAN> GetBEANCartItems();
        CartItem GetCartItem(int id);
        CartItemBEAN GetBEANCartItem(int id);
        void AddCartItem(CartItem cartItem);
        void EditCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);

        // Orders
        IList<Order> GetOrders();
        IList<OrderBEAN> GetBEANOrders();
        Order GetOrder(int id);
        OrderBEAN GetBEANOrder(int id);
        void AddOrder(Order order);
        void EditOrder(Order order);
        void DeleteOrder(Order order);
    }
}
