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
                var uid = User.Identity.GetUserName(); // Gets the logged in user's name and assigns it to the variable uid
                Message message = new Message
                {
                    MessageSubject = subject,
                    MessageBody = body,
                    MessageAuthor = uid, // author is set to the logged in user
                    MessageDate = DateTime.Now // message date is set to today's date
                };

                _companyService.AddMessage(message);

                return RedirectToAction("Dashboard", new { controller = "Home" }); // Redirects the user to their dashboard.
            }
            catch
            {
                return View(); // ** This should be changed at some point to show custom validation or error feedback
            }
        }
    }
}