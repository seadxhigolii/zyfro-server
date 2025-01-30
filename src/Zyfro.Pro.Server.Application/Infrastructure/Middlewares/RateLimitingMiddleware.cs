using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyfro.Pro.Server.Application.Infrastructure.Middlewares
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RateLimitingMiddleware> _logger;
        private readonly IMemoryCache _cache;

        private const int TIME_WINDOW_SECONDS = 60;
        private const int REQUEST_LIMIT = 20;

        public RateLimitingMiddleware(RequestDelegate next, IMemoryCache cache, ILogger<RateLimitingMiddleware> logger)
        {
            _next = next;
            _cache = cache;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(ipAddress))
            {
                await _next(context);
                return;
            }

            var cacheKey = $"RateLimit_{ipAddress}";
            var requestCount = _cache.Get<int>(cacheKey);

            if (requestCount >= REQUEST_LIMIT)
            {
                _logger.LogWarning($"Rate limit exceeded for {ipAddress}");
                context.Response.StatusCode = 429;
                await context.Response.WriteAsync("Too many requests. Please try again later.");
                return;
            }

            _cache.Set(cacheKey, requestCount + 1, TimeSpan.FromSeconds(TIME_WINDOW_SECONDS));

            await _next(context);
        }
    }
}
