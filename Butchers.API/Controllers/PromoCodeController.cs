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
    public class PromoCodeController : ApiController
    {
        OrderService _orderService;
        
        public PromoCodeController()
        {
            _orderService = new OrderService();
        }

        //Get API/PromoCode
        public IHttpActionResult GetPromoCode()
        {
            IEnumerable<PromoCode> Promos = _orderService.GetPromoCodes();
            if (Promos != null)
                return Ok(Promos);
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

        // GET API / PromoCode/ 1 
        public IHttpActionResult GetPromoCode(string id)
        {
            PromoCode code = _orderService.GetPromoCode(id);

            if (code != null)
                return Ok(code);
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
