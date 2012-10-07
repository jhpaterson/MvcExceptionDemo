using System;
using System.Web;
using System.Web.Mvc;
using MvcExceptionDemo.Filters;

namespace MvcExceptionDemo.Controllers
{
    [HandleError(Order=0)]
    public class HomeController : Controller
    {
        // action methods

        public ActionResult Index()
        {
            throw new Exception("Exception occurred in Index action");
        }

        [HandleError(Order=1,View = "BadError", ExceptionType = typeof(NotImplementedException))]
        public ActionResult About()
        {
            throw new NotImplementedException("NotImplementedException occurred in About action");
        }

        [LogAndHandleError(Order=1)]
        public ActionResult Contact()
        {
            throw new Exception("Exception occurred in Contact action");
        }

        // Handle OnException event for this controller
        protected override void OnException(ExceptionContext filterContext)
        {
            // log error
            System.Text.StringBuilder message = new System.Text.StringBuilder();
            message.AppendLine(DateTime.Now.ToString());
            message.AppendLine(filterContext.Exception.ToString());
            message.AppendLine("=========================================");

            string logFile = HttpContext.Request.MapPath("/Log/controllererrors.txt");
            System.IO.File.AppendAllText(logFile, message.ToString());
        }
    }

}
