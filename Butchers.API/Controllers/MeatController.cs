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
    }
}
