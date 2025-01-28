using Zyfro.Pro.Server.Common.Helpers;

namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class HelperExtension
    {
        public static void UseHelpers(this IApplicationBuilder app)
        {
            AuthHelper.Configure(app.ApplicationServices.GetService<IHttpContextAccessor>());
        }
    }
}
