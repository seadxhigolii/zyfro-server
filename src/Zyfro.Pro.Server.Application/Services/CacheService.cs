using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Zyfro.Pro.Server.Application.Interfaces;

namespace Zyfro.Pro.Server.Application.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _cache;

        public CacheService(IConnectionMultiplexer redis)
        {
            _cache = redis.GetDatabase();
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var jsonData = JsonSerializer.Serialize(value);
            await _cache.StringSetAsync(key, jsonData, expiration);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var jsonData = await _cache.StringGetAsync(key);
            return jsonData.HasValue ? JsonSerializer.Deserialize<T>(jsonData) : default;
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.KeyDeleteAsync(key);
        }
    }
}
