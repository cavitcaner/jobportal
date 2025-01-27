using JobPortal.Core;
using JobPortal.Core.Redis;
using JobPortal.Core.Statics;
using JobPortal.JobPostingService.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System.Text.Json;

namespace JobPortal.JobPostingService.Infrastructure.Cache.MemoryCache
{
    public class MemoryCacheService<T> : ICacheService<T> where T : class
    {
        private readonly IMemoryCache _cacheService;
        public MemoryCacheService(IMemoryCache cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<T?> GetAsync(string key)
        {
            if (_cacheService.TryGetValue(key, out T response))
            {
                return response;
            }

            return default;
        }

        public async Task<List<T>?> GetListAsync(string key)
        {
            if (_cacheService.TryGetValue(key, out List<T> response))
            {
                return response;
            }

            return default;
        }

        public async Task RemoveAsync(string key)
        {
            _cacheService.Remove(key);
        }

        public async Task SetAsync(string key, List<T> value, TimeSpan expiration)
        {
            _cacheService.Set(key, value, expiration);
        }
    }
}
