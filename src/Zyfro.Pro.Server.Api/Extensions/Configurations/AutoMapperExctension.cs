using Zyfro.Pro.Server.Application.Infrastructure.AutoMapper;

namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class AutoMapperExctension
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(opts =>
            {
                opts.AddProfile<MapperProfileLocator>();
            });
        }
    }
}
