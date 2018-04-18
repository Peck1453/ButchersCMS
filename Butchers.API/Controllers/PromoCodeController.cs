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
            IEnumerable<PromoCode> Promos = _orderService.GetPromoCodes(); // Gets a list of all promo codes

            if (Promos != null) // If the list of promo codes is not empty
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
            PromoCode code = _orderService.GetPromoCode(id); // Gets an individual promo code from the id (code) which is passed

            if (code != null) // checks that the promo code exists
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
