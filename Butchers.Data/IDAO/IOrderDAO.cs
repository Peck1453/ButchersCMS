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
        int CountPromoCodes();
        PromoCode GetPromoCode(string id);
        void AddPromoCode(PromoCode code);
        void EditPromoCode(PromoCode code);

        //Promocode BEANS 
        IList<PromoCodeBEAN> GetBEANPromoCodes();
        PromoCodeBEAN GetBEANPromoCode(string id);

        //Promocode APIS
        bool AddAPIPromocode(PromoCode code);
        bool EditAPIPromocode(PromoCode code);

        // CartItems
        IList<CartItem> GetCartItems();
        CartItem GetCartItem(int id);
        void AddCartItem(CartItem cartItem);
        void EditCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);

        // CartItem BEANs
        IList<CartItemBEAN> GetBEANCartItems();
        IList<CartItemBEAN> GetCartItemsByCartId(int cartId);
        CartItemBEAN GetBEANCartItem(int id);

        //Cart
        IList<Cart> GetCarts();
        int CountCarts();
        Cart GetCart(int id);
        int AddCartAndReturnId(Cart cart);

        //Cart Bean
        IList<CartBEAN> GetBEANCarts();
        CartBEAN GetBEANCart(int id);

        // Order
        IList<Order> GetOrders();
        int CountOrders();
        Order GetOrder(int id);
        //void AddOrder(Order order);
        int AddOrderAndReturnId(Order order);

        //OrderBEAN
        IList<OrderBEAN> GetBEANOrders();
        IList<OrderBEAN> GetBEANCustomerOrders(string uid);
        OrderBEAN GetBEANOrder(int id);

        // OrderDetails
        IList<OrderDetails> GetOrderDetails();
        OrderDetails GetOrderDetail(int id);
        OrderDetails ToggleCollected(int id);
        void AddOrderDetails(OrderDetails orderDetails);
        void EditOrderDetails(OrderDetails orderDetails);
        int countOrdersCollected();
        int countOrdersCancelled();



        // OrderDetails BEANs
        IList<OrderDetailsBEAN> GetBEANOrderDetails();
        OrderDetailsBEAN GetBEANOrderDetail(int id);

        // Calculations
        decimal GetCartCost(int cartId);
        decimal GetCostAfterDiscount(decimal currentTotal, string promoCode);
    }
}
