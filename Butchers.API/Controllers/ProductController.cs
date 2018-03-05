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
    public class ProductController : ApiController
    {
        ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }
        // GET: api/Product
        public IHttpActionResult GetProduct()
        {
            IEnumerable<Product> products = _productService.GetProducts();

            if (products != null)
                return Ok(products);
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

        // GET: api/Product/1
        public IHttpActionResult GetProduct(int id)
        {
            Product product = _productService.GetProduct(id);

            if (product != null)
                return Ok(product);
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

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
