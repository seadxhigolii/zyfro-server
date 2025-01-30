using Zyfro.Pro.Server.Common.Helpers;

namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class HelperExtension
    {
        public static void UseHelpers(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            AuthHelper.Configure(httpContextAccessor);
        }
    }
}
