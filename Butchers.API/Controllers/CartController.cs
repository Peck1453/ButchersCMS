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
    public class CartController : ApiController
    {
        OrderService _orderService;

        public CartController()
        {
            _orderService = new OrderService();
        }

       
        // POST: api/Cart
        public HttpResponseMessage PostCart(Cart cart)
        {
            if (_orderService.AddAPICart(cart) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cart);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/Cart/" + cart.CartId.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, cart);
                return response;
            }
        }

        
    }
}
