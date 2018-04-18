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
    }
}
