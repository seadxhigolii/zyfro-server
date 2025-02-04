namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class CorsExtension
    {
        public const string corsPolicyName = "SiteCorsPolicy";
        public static void AddSiteCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName, builder =>
                {
                    builder.WithOrigins("https://localhost:44319")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }

        public static void UseSiteCors(this IApplicationBuilder app)
        {
            app.UseCors(corsPolicyName);
        }
    }
}
