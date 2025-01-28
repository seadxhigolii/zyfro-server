using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class DbContextExtension
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProDbContext, ProDbContext>();

            services.AddDbContext<ProDbContext>(x => x.UseNpgsql(configuration.GetConnectionString("Database"), option =>
            {
                option.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            }));
        }
    }
}
