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

    //Get API/ PromoCode

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

        public IHttpActionResult GetPromoCode( string id)

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


     //  POST : API/ PromoCode 

        public HttpResponseMessage PostPromoCode (PromoCode code)
        {
            if (_orderService.AddAPIPromocode(code) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, code);
                response.Headers.Location = new Uri(Request.RequestUri, "api/PromoCode" + code.Code.ToString());
                return response;
            }
            else
            {

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, code);
                return response;
            }
        }

        // PUT: api/Meat
        public HttpResponseMessage PutPromoCode(PromoCode promoCode)
        {
            if (_orderService.EditAPIPromocode(promoCode) == true)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Accepted, promoCode);
                response.Headers.Location = new Uri(Request.RequestUri, "/api/PromoCode/" + promoCode.Code.ToString());
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable, promoCode);
                return response;
            }
        }

        // Delete : API / PromoCode 
        public HttpResponseMessage DeletePromoCode(string id)
        {
            PromoCode code =_orderService.GetPromoCode(id);
            if (code == null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, id);
                return response;
            }
            else
            {
                if(_orderService.DeleteAPIPromoCode(code))
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK,  code);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, id);
                    return response;
                }
            }
        }
    }
}
