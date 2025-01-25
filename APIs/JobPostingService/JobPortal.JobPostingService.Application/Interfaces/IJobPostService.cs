using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface IJobPostService
    {
        Task CreateJobPostAsync(JobPost jobPost, CancellationToken cancellationToken);
        Task<JobPost> GetJobPostByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ICollection<JobPost>> GetAllJobPostsAsync(CancellationToken cancellationToken);
    }
} 