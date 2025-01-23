using JobPortal.EmployerService.Domain;

namespace JobPortal.EmployerService.Application.Services;

public interface IEmployerService
{
    Task<Employer> CreateEmployerAsync(Employer employer);
    Task<List<Employer>> GetAllEmployersAsync();
    Task<Employer?> GetEmployerByIdAsync(Guid id);
    Task<Employer> UpdateEmployerAsync(Employer employer);
    Task DeleteEmployerAsync(Guid id);
} 