using JobPortal.EmployerService.Domain.Entities;

namespace JobPortal.EmployerService.Application.Interfaces;

public interface IEmployerService
{
    Task CreateEmployerAsync(Employer employer, CancellationToken cancellationToken);
    Task<ICollection<Employer>> GetAllEmployersAsync(CancellationToken cancellationToken);
    Task<Employer?> GetEmployerByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateEmployerAsync(Employer employer, CancellationToken cancellationToken);
    Task DeleteEmployerAsync(Guid id, CancellationToken cancellationToken);
    Task<Employer?> GetEmployerByCompanyNameAndPhoneAsync(string companyName, string phoneNumber, CancellationToken cancellationToken);
    Task CheckIfExistsCompanyPhoneUniqueAsync(string companyName, string phoneNumber, CancellationToken cancellationToken);
}