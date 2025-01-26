using JobPortal.Core.Statics;
using JobPortal.JobPostingService.Application.DTOs.Elasticsearch;
using JobPortal.JobPostingService.Application.Interfaces;
using Nest;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Configuration;
using JobPortal.Core.Redis;
using JobPortal.JobPostingService.Infrastructure.Cache.Redis;

namespace JobPortal.JobPostingService.Infrastructure.Services.Elasticsearch
{
    public class JobPostElasticService : IJobPostElasticService
    {
        private readonly IElasticClient _elasticClient;
        private const string _indexName = "jobposts";
        private readonly HateWordsRedisService _hateWordsRedisService;
        public JobPostElasticService(IElasticClient elasticClient, HateWordsRedisService hateWordsRedisService)
        {
            _elasticClient = elasticClient;
            _hateWordsRedisService = hateWordsRedisService;
        }

        public async Task<JobPostElasticModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _elasticClient.GetAsync<JobPostElasticModel>(id, x => x.Index(_indexName), cancellationToken);

            if (!response.IsValid)
            {
                throw new Exception($"Job Post not found: {response.OriginalException?.Message}");
            }

            if (!response.Found)
            {
                throw new Exception($"Job Post not found");
            }
            return response.Source;
        }

        public async Task IndexDataAsync(JobPostElasticModel entity, CancellationToken cancellationToken)
        {
            List<string> hateWordList = await _hateWordsRedisService.GetListAsync();

            entity.CalculateJobPoint(hateWordList);

            var response = await _elasticClient.IndexAsync(entity, i => i .Index(_indexName), cancellationToken);

            if (!response.IsValid)
            {
                throw new Exception($"Failed to index document: {response.OriginalException.Message}");
            }
        }

        public async Task<IEnumerable<JobPostElasticModel>> SearchDataAsync(string query, CancellationToken cancellationToken)
        {
            var searchResponse = await _elasticClient.SearchAsync<JobPostElasticModel>(s => s
                .Index(_indexName)
                .Query(q => q
                    .Bool(b => b
                        .Must(
                            x => x.DateRange(r => r
                                .Field(f => f.ExpirationDate)
                                .GreaterThanOrEquals(DateTime.UtcNow)
                            ),
                            x => !string.IsNullOrEmpty(query) ? x
                                .MultiMatch(mm => mm
                                    .Query(query)
                                    .Type(TextQueryType.BestFields)
                                ) : x.MatchAll()
                        )
                    )
                )
                .Size(100)
            );

            if (!searchResponse.IsValid)
            {
                throw new Exception($"Search failed: {searchResponse.OriginalException.Message}");
            }

            var jobPosts = searchResponse.Documents;
            return jobPosts;
        }

        public async Task<IEnumerable<JobPostElasticModel>> GetAllDataAsync(CancellationToken cancellationToken)
        {
            var searchResponse = await _elasticClient.SearchAsync<JobPostElasticModel>(s => s
                .Index(_indexName)
                .Query(x => x.DateRange(r => r
                                .Field(f => f.ExpirationDate)
                                .GreaterThanOrEquals(DateTime.UtcNow)
                    )
                )
                .Size(100)
            );

            if (!searchResponse.IsValid)
            {
                throw new Exception($"Search failed: {searchResponse.OriginalException.Message}");
            }

            var jobPosts = searchResponse.Documents;
            return jobPosts;
        }
    }

}
