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

        // GET: api/OrderDetails
        public IHttpActionResult GetOrderDetails()
        {
            IEnumerable<OrderDetails> orderDetails = _orderService.GetOrderDetails();

            if (orderDetails != null)
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

        // GET: api/OrderDetails/1
        public IHttpActionResult GetOrderDetails(int id)
        {
            OrderDetails orderDetails = _orderService.GetOrderDetail(id);

            if (orderDetails != null)
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

        // POST: api/Meat
        public HttpResponseMessage PostOrderDetails(OrderDetails orderDetails)
        {
            if (_orderService.AddAPIOrderDetails(orderDetails) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, orderDetails);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/OrderDetails/" + orderDetails.OrderDetailsId.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, orderDetails);
                return response;
            }
        }

        // PUT: api/Meat
        public HttpResponseMessage PutOrderDetails(OrderDetails orderDetails)
        {
            if (_orderService.EditAPIOrderDetails(orderDetails) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Accepted, orderDetails);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/OrderDetails/" + orderDetails.OrderDetailsId.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, orderDetails);
                return response;
            }
        }

        // DELETE: api/Meat/1
        public HttpResponseMessage DeleteOrderDetails(int id)
        {
            OrderDetails orderDetails = _orderService.GetOrderDetail(id);
            if (orderDetails == null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, id);
                return response;
            }
            else
            {
                if (_orderService.DeleteAPIOrderDetails(orderDetails))
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, orderDetails);
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
