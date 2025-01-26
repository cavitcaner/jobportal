using JobPortal.Core;
using JobPortal.Core.Redis;
using JobPortal.Core.Statics;
using StackExchange.Redis;
using System.Text.Json;

namespace JobPortal.JobPostingService.Infrastructure.Cache.Redis
{
    public class HateWordsRedisService : ARedisService<string>
    {
        public HateWordsRedisService(IConnectionMultiplexer redis) : base(Consts.RedisKeys.HateWordsRedisKey, redis)
        {
        }
    }
}
