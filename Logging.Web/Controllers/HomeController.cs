using Logging.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Web.Controllers
{
    public class HomeController : Controller
    {
        // 1. Yol
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ILoggerFactory _loggerFactory;

        public HomeController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public IActionResult Index()
        {
            var _logger = _loggerFactory.CreateLogger("HomeSınıfı");

            _logger.LogTrace("Index sayfasına girildi.");
            _logger.LogDebug("Index sayfasına girildi.");
            _logger.LogInformation("Index sayfasına girildi.");
            _logger.LogWarning("Index sayfasına girildi.");
            _logger.LogError("Index sayfasına girildi.");
            _logger.LogCritical("Index sayfasına girildi.");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
