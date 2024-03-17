using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ErrorHandling.Web.Filter
{
    public class CustomHandleExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public string ErrorPage { get; set; }

        public override void OnException(ExceptionContext context)
        {
            // Loglama yapıldı.

            if (ErrorPage == "Hata1")
            {
                // farklı bir kaynak kodlama
            }
            else
            {
                // farklı bir kaynak kodlama
            }

            var result = new ViewResult() { ViewName = ErrorPage };
            result.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState);
            result.ViewData.Add("Exception", context.Exception);
            result.ViewData.Add("Url", context.HttpContext.Request.Path.Value);
            context.Result = result;
        }
    }
}
