using System;
using System.Web;
using System.Web.Mvc;

namespace MvcExceptionDemo.Filters
{
    public class LogAndHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            System.Text.StringBuilder message = new System.Text.StringBuilder();
            message.AppendLine(DateTime.Now.ToString());
            message.AppendLine(context.Exception.ToString());
            message.AppendLine("=========================================");

            string logFile = HttpContext.Current.Request.MapPath("/Log/filtererrors.txt");
            System.IO.File.AppendAllText(logFile, message.ToString());

            base.OnException(context);
        }
    }
}