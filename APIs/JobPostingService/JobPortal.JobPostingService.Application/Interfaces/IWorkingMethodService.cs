using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface IWorkingMethodService
    {
        /// <summary>
        /// Veritabanına yeni bir çalışma türü ekler
        /// </summary>
        /// <returns></returns>
        Task CreateWorkingMethodAsync(WorkingMethod workingMethod, CancellationToken cancellationToken);
        /// <summary>
        /// Veritabanından belirli bir çaışma tipini döner
        /// </summary>
        /// <returns></returns>
        Task<WorkingMethod> GetWorkingMethodByIdAsync(Guid id, CancellationToken cancellationToken);
        /// <summary>
        /// Veritabanından bütün çalışma türü listesini döner
        /// </summary>
        /// <returns></returns>
        Task<ICollection<WorkingMethod>> GetAllWorkingMethodsAsync(CancellationToken cancellationToken);
    }
} 
