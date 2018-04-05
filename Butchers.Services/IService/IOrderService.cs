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
        bool EditAPIPromocode(PromoCode code);
        bool DeleteAPIPromoCode(PromoCode code);

        // Cart Items
        IList<CartItem> GetCartItems();
        CartItem GetCartItem(int id);
        decimal GetCartCost(int cartId);
        decimal GetCostAfterDiscount(decimal currentTotal, string promoCode);
        void AddCartItem(CartItem cartItem);
        void EditCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);

        // CartItem BEANs
        IList<CartItemBEAN> GetBEANCartItems();
        IList<CartItemBEAN> GetCartItemsByCartId(int cartId);
        CartItemBEAN GetBEANCartItem(int id);

        // CartItem APIs
        bool AddAPICartItem(CartItem cartItem);
        bool DeleteAPICartItem(CartItem cartItem);
        bool EditAPICartItem(CartItem cartItem);


        //Cart
        IList<Cart> GetCarts();
        Cart GetCart(int id);
        void AddCart(Cart cart);
        int AddCartAndReturnId(Cart cart);
        void EditCart(Cart cart);
        void DeleteCart(Cart cart);

        // CartItem BEANs
        IList<CartBEAN> GetBEANCarts();
        CartBEAN GetBEANCart(int id);

        // CartAPIs
        bool AddAPICart(Cart cart);
        bool EditAPICart(Cart cart);
        bool DeleteAPICart(Cart cart);

        // Orders
        IList<Order> GetOrders();
        Order GetOrder(int id);
        void AddOrder(Order order);
        int AddOrderAndReturnId(Order order);
        void EditOrder(Order order);
        void DeleteOrder(Order order);

        // OrderBEAN
        IList<OrderBEAN> GetBEANOrders();
        IList<OrderBEAN> GetBEANCustomerOrders(string uid);
        OrderBEAN GetBEANOrder(int id);
        
        //OrderAPI
        bool AddAPIOrder(Order order);
        bool EditAPIOrder(Order order);
        bool DeleteAPIOrder(Order order);

        // OrderDetails
        IList<OrderDetails> GetOrderDetails();
        OrderDetails GetOrderDetail(int id);
        OrderDetails ToggleCollected(int id);
        void AddOrderDetails(OrderDetails orderDetails);
        void EditOrderDetails(OrderDetails orderDetails);
        void DeleteOrderDetails(OrderDetails orderDetails);

        // OrderDetails BEANs
        IList<OrderDetailsBEAN> GetBEANOrderDetails();
        OrderDetailsBEAN GetBEANOrderDetail(int id);

        // OrderDetails APIs
        bool AddAPIOrderDetails(OrderDetails orderDetails);
        bool EditAPIOrderDetails(OrderDetails orderDetails);
        bool DeleteAPIOrderDetails(OrderDetails orderDetails);

    }
}
