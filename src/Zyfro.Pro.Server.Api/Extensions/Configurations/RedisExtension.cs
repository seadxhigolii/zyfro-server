using StackExchange.Redis;
namespace Zyfro.Pro.Server.Api.Extensions.Configurations
{
    public static class RedisExtension
    {
        public static void RedisService(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConfig = configuration.GetSection("Redis");
            string redisConnectionString = $"{redisConfig["Host"]}:{redisConfig["Port"]}";

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));
        }
    }
}
