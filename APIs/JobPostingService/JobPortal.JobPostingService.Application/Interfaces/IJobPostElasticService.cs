using JobPortal.JobPostingService.Application.DTOs.Elasticsearch;

namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface IJobPostElasticService
    {
        /// <summary>
        /// Id'ye göre elasticden kayıt döner
        /// </summary>
        /// <param name="ıd"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<JobPostElasticModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Elasticsearch'e yeni ilan ekler
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task IndexDataAsync(JobPostElasticModel entity, CancellationToken cancellationToken);
        /// <summary>
        /// Elasticsearch'deki henüz süresi dolmamış ilanlar arasında arama yapar.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<JobPostElasticModel>> SearchDataAsync(string query, CancellationToken cancellationToken);
        /// <summary>
        /// Elasticsearch'deki henüz süresi dolmamış ilanları listeler
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<JobPostElasticModel>> GetAllDataAsync(CancellationToken cancellationToken);
        Task<int> GetCountByEmployerIdAsync(Guid employerId, CancellationToken cancellationToken);
    }
}