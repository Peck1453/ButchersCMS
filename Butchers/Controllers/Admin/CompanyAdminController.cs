using Butchers.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers.Admin
{
    [Authorize(Roles = "Manager, Staff")]
    public class CompanyAdminController : ApplicationController
    {
        public CompanyAdminController()
        {

        }


        [HttpGet]
        [Authorize(Roles = "Staff, Manager")]
        public ActionResult AddMessage(string subject, string body)
        {
            try
            {
                var uid = User.Identity.GetUserName();
                Message message = new Message
                {
                    MessageSubject = subject,
                    MessageBody = body,
                    MessageAuthor = uid,
                    MessageDate = DateTime.Now
                };

                _companyService.AddMessage(message);

                return RedirectToAction("Dashboard", new { controller = "Home" });
            }
            catch
            {
                return View();
            }
        }
    }
}