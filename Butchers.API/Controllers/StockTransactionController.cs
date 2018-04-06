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
    public class StockTransactionController : ApiController
    {
        ProductService _productService;
        public StockTransactionController()
        {
            _productService = new ProductService();


        }

        // POST: api/StockTransaction
        public HttpResponseMessage PostStockTransaction(StockTransaction stockTransaction)
        {
            if (_productService.AddAPIStockTransaction(stockTransaction) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, stockTransaction);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/StockTransaction" + stockTransaction.TransactionId.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, stockTransaction);
                return response;
            }
        }

    }
}


