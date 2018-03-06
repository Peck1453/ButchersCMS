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


    }
}
