using Butchers.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Butchers.Controllers
{
    public abstract class ApplicationController : Controller
    {
        public ProductService _productService;
        public OrderService _orderService;
        public CompanyService _companyService;

        public ApplicationController()
        {
            _productService = new ProductService();
            _orderService = new OrderService();
            _companyService = new CompanyService();
        }
    }
}