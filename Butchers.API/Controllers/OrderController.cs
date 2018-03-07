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
    public class OrderController : ApiController
    {
        OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }


        // GET: api/Order
        public IHttpActionResult GetOrder()
        {
            IEnumerable<Order> order = _orderService.GetOrders();

            if (order != null)
                return Ok(order);
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

        // GET: api/Order/5
        public IHttpActionResult GetOrder(int id)
        {
            Order order = _orderService.GetOrder(id);

            if (order != null)
                return Ok(order);
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
        // POST: api/Order
        public HttpResponseMessage PostOrder(Order order)
        {
            if (_orderService.AddAPIOrder(order) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, order);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/Order/" + order.OrderNo.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, order);
                return response;
            }
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {


        }

        // DELETE: api/Order/5
        public HttpResponseMessage DeleteOrder(int id)
        {
            Order order = _orderService.GetOrder(id);
            if (order == null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, id);
                return response;
            }
            else
            {
                if (_orderService.DeleteAPIOrder(order))
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, order);
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
