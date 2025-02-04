using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Application.Interfaces.AWS;
using Zyfro.Pro.Server.Application.Services;
using Zyfro.Pro.Server.Application.Services.AWS;

namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class OwnServiceExtension
    {
        public static void AddOwnService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IS3Service, S3Service>();
        }
    }
}
