using ErrorHandling.Web.Filter;
using ErrorHandling.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandling.Web.Controllers
{
    //[CustomHandleExceptionFilterAttribute(ErrorPage = "Hata1")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[CustomHandleExceptionFilterAttribute(ErrorPage = "Hata1")]

        public IActionResult Index()
        {
            int value1 = 5;
            int value2 = 0;

            int result = value1 / value2;

            return View();
        }

        //[CustomHandleExceptionFilterAttribute(ErrorPage = "Hata2")]
        public IActionResult Privacy()
        {
            throw new FileNotFoundException();
            return View();
        }

        [AllowAnonymous] // Siteye üye olmayanlarda hata sayfasını görsün.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()

        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Path = exception.Path;
            ViewBag.Message = exception.Error.Message;

            return View();
        }

        public IActionResult Hata1()
        {
            return View();
        }

        public IActionResult Hata2()
        {
            return View();
        }
    }
}
