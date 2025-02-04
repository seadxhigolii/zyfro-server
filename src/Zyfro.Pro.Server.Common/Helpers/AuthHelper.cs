using Microsoft.AspNetCore.Http;
using System;
using System.Security.Cryptography;
using Zyfro.Pro.Server.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;

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

        public static string GenerateJwtToken(ApplicationUser user, string secret)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("companyId", user.CompanyId.ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMonths(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public static string HashPassword(string password, string salt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 100000, HashAlgorithmName.SHA256))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(32)); // 256-bit hash
            }
        }
        public static bool VerifyPassword(string inputPassword, string storedHash, string storedSalt)
        {
            string hashedInput = HashPassword(inputPassword, storedSalt);

            return CryptographicOperations.FixedTimeEquals(
                Convert.FromBase64String(hashedInput),
                Convert.FromBase64String(storedHash)
            );
        }

        public static string GetCurrentUserId()
        {
            var httpContext = HttpContextAccessor?.HttpContext;
            if (httpContext == null || !httpContext.User.Identity.IsAuthenticated)
                return null;

            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return null;

            return userId;
        }

        public static string GetCurrentCompanyId()
        {
            var httpContext = HttpContextAccessor?.HttpContext;
            if (httpContext == null || !httpContext.User.Identity.IsAuthenticated)
                return null;

            var userId = httpContext.User.FindFirst("companyId")?.Value;
            if (string.IsNullOrEmpty(userId))
                return null;

            return userId;
        }
    }
}
