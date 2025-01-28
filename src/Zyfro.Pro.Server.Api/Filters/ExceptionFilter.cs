using Zyfro.Pro.Server.Common.Exceptions;
using Zyfro.Pro.Server.Common.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Zyfro.Pro.Server.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException validatorException)
                context.ExceptionFilerResponse(HttpStatusCode.BadRequest, new { validatorException.Title, validatorException.Errors });
        }
    }
}
