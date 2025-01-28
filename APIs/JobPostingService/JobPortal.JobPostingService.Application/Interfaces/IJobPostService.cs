using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface IJobPostService
    {
        /// <summary>
        /// Veritabanına yeni bir ilan eklemek için kullanılır.
        /// </summary>
        /// <returns></returns>
        Task CreateJobPostAsync(JobPost jobPost, CancellationToken cancellationToken);
        /// <summary>
        /// Veritabanından belirli bir ilan bilgilerini döner. 
        /// </summary>
        /// <returns></returns>
        Task<JobPost> GetJobPostByIdAsync(Guid id, CancellationToken cancellationToken);
        /// <summary>
        /// Veritabanında olan büün ilanları listeler.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<JobPost>> GetAllJobPostsAsync(CancellationToken cancellationToken);
    }
} 
