using Butchers.Data;
using Butchers.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Butchers.API.Controllers
{
    public class CartItemController : ApiController
    {
        OrderService _orderService;

        public CartItemController()
        {
            _orderService = new OrderService();
        }

        // GET: api/CartItem
        public IHttpActionResult GetCartItem()
        {
            IEnumerable<CartItem> cartItems = _orderService.GetCartItems();

            if (cartItems != null)
                return Ok(cartItems);
            else
            {
                HttpResponseMessage response;
                response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent
                };
                return (IHttpActionResult)response;
            }
        }

        // GET: api/CartItem/1
        public IHttpActionResult GetCartItem(int id)
        {
            CartItem cartItems = _orderService.GetCartItem(id);

            if (cartItems != null)
                return Ok(cartItems);
            else
            {
                HttpResponseMessage response;
                response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent
                };

                return (IHttpActionResult)response;
            }
        }
    }
}
