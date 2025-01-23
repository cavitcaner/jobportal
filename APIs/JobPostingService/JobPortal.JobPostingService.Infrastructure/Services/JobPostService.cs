using JobPortal.Core.Repository;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Infrastructure.Services
{
    public class JobPostService : IJobPostService
    {
        private readonly IGenericRepository<JobPost> _genericRepository;
        public JobPostService(IGenericRepository<JobPost> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task CreateJobPostAsync(JobPost jobPost, CancellationToken cancellationToken)
        {
            await _genericRepository.AddAsync(jobPost, cancellationToken);
        }

        public async Task<JobPost> GetJobPostByIdAsync(Guid id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<ICollection<JobPost>> GetAllJobPostsAsync()
        {
            return await _genericRepository.GetAllAsync();
        }
    }
} 