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
    public class OrderDetailsController : ApiController
    {
        OrderService _orderService;

        public OrderDetailsController()
        {
            _orderService = new OrderService();
        }

        // GET: api/OrderDetails/1
        public IHttpActionResult GetOrderDetails(int id)
        {
            OrderDetails orderDetails = _orderService.GetOrderDetail(id); // Finds the order from the id (order no)

            if (orderDetails != null) // Checks whether the order details exist
                return Ok(orderDetails);
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
