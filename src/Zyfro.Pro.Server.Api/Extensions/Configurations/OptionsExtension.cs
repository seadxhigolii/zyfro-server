namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class OptionsExtension
    {
        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddOptions<...>()
            //    .Bind(configuration.GetSection("Smtp"))
            //    .ValidateDataAnnotations()
            //    .ValidateOnStart();
        }
    }
}
