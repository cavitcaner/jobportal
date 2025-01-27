using Bogus.Bson;
using JobPortal.Core;
using JobPortal.Core.Redis;
using JobPortal.Core.Statics;
using JobPortal.JobPostingService.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System.Text.Json;

namespace JobPortal.JobPostingService.Infrastructure.Cache.MemoryCache
{
    public class HateWordsCacheService
    {
        private readonly ICacheService<string> _cacheService;
        public HateWordsCacheService(ICacheService<string> cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<List<string>?> GetListAsync()
        {
            return await _cacheService.GetListAsync(Consts.CacheKeys.HateWordsKey);
        }

        public async Task RemoveAsync()
        {
            await _cacheService.RemoveAsync(Consts.CacheKeys.HateWordsKey);
        }

        public async Task SetAsync(List<string> value, TimeSpan expiration)
        {
            await _cacheService.SetAsync(Consts.CacheKeys.HateWordsKey, value, expiration);
        }
    }
}
