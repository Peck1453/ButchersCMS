using Butchers.Data;
using Butchers.Data.BEANS;
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
            IEnumerable<ProductItemBEAN> productItem = _productService.GetBEANProductItems();

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

        // PUT api/ProducttItem
        public HttpResponseMessage PutProductItem(ProductItem productItem)
        {
            if (_productService.EditAPIProductItem(productItem) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Accepted, productItem);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/ProductItem/" + productItem.ProductItemId.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, productItem);
                return response;
            }
        }
        
        
    }
}
