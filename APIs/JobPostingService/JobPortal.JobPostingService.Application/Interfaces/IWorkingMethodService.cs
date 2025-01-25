using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface IWorkingMethodService
    {
        Task CreateWorkingMethodAsync(WorkingMethod workingMethod, CancellationToken cancellationToken);
        Task<WorkingMethod> GetWorkingMethodByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ICollection<WorkingMethod>> GetAllWorkingMethodsAsync(CancellationToken cancellationToken);
    }
} 