using Zyfro.Pro.Server.Api.Extensions.Configurations;
using Zyfro.Pro.Server.Api.Filters;

namespace Zyfro.Pro.Server.Api.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(opt => opt.Filters.Add<ExceptionFilter>());
            services.AddSiteCors();
            services.AddDbContext(configuration);
            services.AddIdentity();
            services.AddJwtAuthentication(configuration);
            services.AddSiteSwagger();
            services.AddMediator();
            services.AddOwnService();
            services.AddFluentValidations();
            services.AddMapper();
            services.AddOptions(configuration);
            services.AddMemoryCache();

            return services;
        }

        public static WebApplication UseServices(this WebApplication app)
        {
            app.UseSiteCors();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHelpers();
            return app;
        }
    }
}
