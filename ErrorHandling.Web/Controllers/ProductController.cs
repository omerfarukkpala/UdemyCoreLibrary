using ErrorHandling.Web.Filter;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ErrorHandling.Web.Controllers
{
    //[CustomHandleExceptionFilterAttribute(ErrorPage = "Hata2")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Veri tabanında bir hata meydana geldi.");
            return View();
        }
    }
}
