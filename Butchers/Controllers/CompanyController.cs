using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers
{
    [Authorize(Roles = "Admin, Manager, Staff, Customer")]
    public class CompanyController : ApplicationController
    {
        public CompanyController()
        {

        }

        // PromoCodes
        [Authorize(Roles = ("Customer"))]
        public ActionResult _Message()
        {
            return PartialView(_companyService.GetMessages());
        }
    }
}