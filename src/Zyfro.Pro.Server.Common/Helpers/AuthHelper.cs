using Microsoft.AspNetCore.Http;
using System;

namespace Zyfro.Pro.Server.Common.Helpers
{
    public static class AuthHelper
    {
        public static IHttpContextAccessor HttpContextAccessor { get; private set; }

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Returns authenticated user token.
        /// </summary>
        public static string Token
            => HttpContextAccessor.HttpContext.Request.Headers["Authorization"];
    }
}
