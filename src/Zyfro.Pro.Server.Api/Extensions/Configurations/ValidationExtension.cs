using Zyfro.Pro.Server.Application.Interfaces;
using FluentValidation;

namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class ValidationExtension
    {
        public static void AddFluentValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(IProDbContext).Assembly);
        }
    }
}
