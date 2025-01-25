using JobPortal.Core.Repository;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Domain.Entities;
using System.Threading;

namespace JobPortal.JobPostingService.Infrastructure.Services
{
    public class WorkingMethodService : IWorkingMethodService
    {
        private readonly IGenericRepository<WorkingMethod> _genericRepository;
        public WorkingMethodService(IGenericRepository<WorkingMethod> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task CreateWorkingMethodAsync(WorkingMethod workingMethod, CancellationToken cancellationToken)
        {
            await _genericRepository.AddAsync(workingMethod, cancellationToken);
        }

        public async Task<WorkingMethod> GetWorkingMethodByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<ICollection<WorkingMethod>> GetAllWorkingMethodsAsync(CancellationToken cancellationToken)
        {
            return await _genericRepository.GetAllAsync(cancellationToken);
        }
    }
} 