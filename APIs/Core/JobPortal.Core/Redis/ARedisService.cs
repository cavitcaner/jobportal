using StackExchange.Redis;
using System.Text.Json;

namespace JobPortal.Core.Redis
{
  
    public abstract class ARedisService<T>  where T : class
    {
        private readonly IConnectionMultiplexer Redis;
        protected readonly IDatabase RedisDb;
        protected readonly string Key;
        public ARedisService(string key, IConnectionMultiplexer redis)
        {
            Key = key;
            Redis = redis;
            RedisDb = redis.GetDatabase();
        }
        public virtual async Task<T?> GetAsync()
        {
            var value = await RedisDb.StringGetAsync(Key);
            if (value.IsNull)
                return default;

            return JsonSerializer.Deserialize<T?>(value.ToString());
        }

        public virtual async Task<List<T>?> GetListAsync()
        {
            var value = await RedisDb.StringGetAsync(Key);
            if (value.IsNull)
                return default;

            return JsonSerializer.Deserialize<List<T>?>(value.ToString());
        }

        public virtual async Task RemoveAsync()
        {
            await RedisDb.KeyDeleteAsync(Key);
        }

        public virtual async Task SetAsync(List<T> value, TimeSpan expiration)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            await RedisDb.StringSetAsync(Key, serializedValue, expiration);
        }
    }
}
