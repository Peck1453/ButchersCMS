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

        public ApplicationController()
        {
            _productService = new ProductService();
            _orderService = new OrderService();
        }
    }
}