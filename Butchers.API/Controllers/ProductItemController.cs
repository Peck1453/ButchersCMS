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
    public class ProductItemController : ApiController
    {
        ProductService _productService;

        public ProductItemController()
        {
            _productService = new ProductService();
        }

        // GET: api/ProductItems
        public IHttpActionResult GetProductItem()
        {
            IEnumerable<ProductItem> product_item = _productService.GetProductItems();

            if (product_item != null)
                return Ok(product_item);
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

        // GET: api/ProductItem/1
        public IHttpActionResult GetProductItem(int id)
        {
            ProductItem productItem = _productService.GetProductItem(id);

            if (productItem != null)
                return Ok(productItem);
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

        // POST: api/ProductItem
        public HttpResponseMessage PostProductItem(ProductItem productItem)
        {
            if (_productService.AddAPIProductItem(productItem) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, productItem);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/ProductItem/" + productItem.ProductItemId.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, productItem);
                return response;
            }
        }

        // DELETE: api/ProductItem/1
        public HttpResponseMessage DeleteProductItem(int id)
        {
            ProductItem productItem = _productService.GetProductItem(id);
            if (productItem == null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, id);
                return response;
            }
            else
            {
                if (_productService.DeleteAPIProductItem(productItem))
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, productItem);
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
