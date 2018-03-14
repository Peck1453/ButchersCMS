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

        // GET: api/CartItem
        public IHttpActionResult GetCart()
        {
            IEnumerable<Cart> carts = _orderService.GetCarts();

            if (carts != null)
                return Ok(carts);
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
        public IHttpActionResult GetCart(int id)
        {
            Cart carts = _orderService.GetCart(id);

            if (carts != null)
                return Ok(carts);
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

        // POST: api/Meat
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

        // PUT: api/Meat
        public HttpResponseMessage PutCart(Cart cart)
        {
            if (_orderService.EditAPICart(cart) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Accepted, cart);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/Meat/" + cart.CartId.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, cart);
                return response;
            }
        }

        // DELETE: api/Meat/1
        public HttpResponseMessage DeleteCart(int id)
        {
            Cart cart = _orderService.GetCart(id);
            if (cart == null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, id);
                return response;
            }
            else
            {
                if (_orderService.DeleteAPICart(cart))
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, cart);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, id); // Returns 500
                    return response;
                }
            }
        }
    }
}
