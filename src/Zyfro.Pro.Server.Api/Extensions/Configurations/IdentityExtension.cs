using Microsoft.AspNetCore.Identity;
using Zyfro.Pro.Server.Domain.Entities;
using Zyfro.Pro.Server.Persistence;
using System;

namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class IdentityExtension
    {
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                 .AddEntityFrameworkStores<ProDbContext>()
                 .AddDefaultTokenProviders();
        }
    }
}
