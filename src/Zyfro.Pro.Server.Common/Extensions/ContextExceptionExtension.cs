using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Zyfro.Pro.Server.Common.Extensions
{
    public static class ContextExceptionExtension
    {
        public static void ExceptionFilerResponse(this ExceptionContext context, HttpStatusCode statusCode, object objectMessage = null)
        {
            context.HttpContext.Response.ContentType = "application/json";

            if (objectMessage != null)
                context.Result = new JsonResult(objectMessage);
            else
                context.Result = new JsonResult(new { context.Exception.Message });

            context.HttpContext.Response.StatusCode = (int)statusCode;
        }
    }
}
