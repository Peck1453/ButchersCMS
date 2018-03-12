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
    public class MeatController : ApiController
    {
        ProductService _productService;

        public MeatController()
        {
            _productService = new ProductService();
        }

        // GET: api/Meat
        public IHttpActionResult GetMeat()
        {
            IEnumerable<Meat> meats = _productService.GetMeats();

            if (meats != null)
                return Ok(meats);
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

        // GET: api/Meat/1
        public IHttpActionResult GetMeat(int id)
        {
            Meat meat = _productService.GetMeat(id);

            if (meat != null)
                return Ok(meat);
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
        public HttpResponseMessage PostMeat(Meat meat)
        {
            if (_productService.AddAPIMeat(meat) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, meat);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/Meat/" + meat.MeatId.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, meat);
                return response;
            }
        }

        // PUT: api/Meat
        public HttpResponseMessage PutMeat(Meat meat)
        {
            if (_productService.EditAPIMeat(meat) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Accepted, meat);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/Meat/" + meat.MeatId.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, meat);
                return response;
            }
        }

        // DELETE: api/Meat/1
        public HttpResponseMessage DeleteMeat(int id)
        {
            Meat meat = _productService.GetMeat(id);
            if (meat == null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, id);
                return response;
            }
            else
            {
                if (_productService.DeleteAPIMeat(meat))
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, meat);
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
