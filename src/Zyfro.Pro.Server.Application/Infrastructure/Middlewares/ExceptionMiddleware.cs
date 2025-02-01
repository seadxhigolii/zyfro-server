using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zyfro.Pro.Server.Application.Infrastructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = Log.ForContext<ExceptionMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                LogException(context, ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private void LogException(HttpContext context, Exception ex)
        {
            _logger.Error(ex, "An unhandled exception occurred at {Path}. RequestId: {RequestId}",
                context.Request.Path,
                context.TraceIdentifier);
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error. Please try again later.",
                Details = exception.Message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
