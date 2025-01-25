using JobPortal.Core.Repository;
using JobPortal.Core.Statics;
using JobPortal.JobPostingService.Application.DTOs.Elasticsearch;
using JobPortal.JobPostingService.Application.Interfaces;
using Nest;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JobPortal.JobPostingService.Infrastructure.Services.Elasticsearch
{
    public class JobPostElasticService : IJobPostElasticService
    {
        private readonly IElasticClient _elasticClient;

        public JobPostElasticService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<JobPostElasticModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _elasticClient.GetAsync<JobPostElasticModel>(id, x => x.Index<JobPostElasticModel>(), cancellationToken);

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
            var response = await _elasticClient.IndexDocumentAsync(entity);
            if (!response.IsValid)
            {
                throw new Exception($"Failed to index document: {response.OriginalException.Message}");
            }
        }

        public async Task<IEnumerable<JobPostElasticModel>> SearchDataAsync(string query, CancellationToken cancellationToken)
        {
            var searchResponse = await _elasticClient.SearchAsync<JobPostElasticModel>(s => s
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
                .Query(x => x.DateRange(r => r
                                .Field(f => f.ExpirationDate)
                                .GreaterThanOrEquals(DateTime.UtcNow)
                    )
                )
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
