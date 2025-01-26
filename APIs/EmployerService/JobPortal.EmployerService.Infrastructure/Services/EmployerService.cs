using JobPortal.Core.Helpers;
using JobPortal.Core.Repository;
using JobPortal.Core.UnitOfWork;
using JobPortal.EmployerService.Application.Interfaces;
using JobPortal.EmployerService.Domain.Entities;
using JobPortal.EmployerService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.EmployerService.Infrastructure.Services;

public class EmployerService : IEmployerService
{
    private readonly IGenericRepository<Employer> _employerRepository;
    public EmployerService(IGenericRepository<Employer> employerRepository)
    {
        _employerRepository = employerRepository;
    }

    public async Task CreateEmployerAsync(Employer employer, CancellationToken cancellationToken)
    {
        await _employerRepository.AddAsync(employer, cancellationToken);
    }

    public async Task<ICollection<Employer>> GetAllEmployersAsync(CancellationToken cancellationToken)
    {
        return await _employerRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Employer?> GetEmployerByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _employerRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task UpdateEmployerAsync(Employer employer, CancellationToken cancellationToken)
    {
        await _employerRepository.UpdateAsync(employer, cancellationToken);
    }

    public async Task DeleteEmployerAsync(Guid id, CancellationToken cancellationToken)
    {
        var employer = await _employerRepository.GetByIdAsync(id, cancellationToken);
        ExceptionHelper.ThrowIfNullOrEmpty(employer, "Ýþveren bulunamadý.");
        await _employerRepository.DeleteAsync(employer, cancellationToken);
    }

    public async Task<Employer?> GetEmployerByCompanyNameAndPhoneAsync(string companyName, string phoneNumber, CancellationToken cancellationToken)
    {
        var employer = await _employerRepository.GetWithQueryAsync(x => x.CompanyName == companyName && x.PhoneNumber == phoneNumber, cancellationToken);
        return employer.FirstOrDefault();
    }

    public async Task CheckIfExistsCompanyPhoneUniqueAsync(string companyName, string phoneNumber, CancellationToken cancellationToken)
    {
        var employerExists = await _employerRepository.AnyWithQueryAsync(x => x.CompanyName == companyName && x.PhoneNumber == phoneNumber, cancellationToken);
        ExceptionHelper.ThrowIf(employerExists, "Bu þirket ve telefona ait daha önceden kayýt oluþturulmuþ!");
    }
}