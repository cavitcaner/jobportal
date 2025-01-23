using JobPortal.EmployerService.Application.Services;
using JobPortal.EmployerService.Domain;
using JobPortal.EmployerService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.EmployerService.Infrastructure.Services;

public class EmployerService : IEmployerService
{
    private readonly EmployerDbContext _context;

    public EmployerService(EmployerDbContext context)
    {
        _context = context;
    }

    public async Task<Employer> CreateEmployerAsync(Employer employer)
    {
        await _context.Employers.AddAsync(employer);
        await _context.SaveChangesAsync();
        return employer;
    }

    public async Task<List<Employer>> GetAllEmployersAsync()
    {
        return await _context.Employers.ToListAsync();
    }

    public async Task<Employer?> GetEmployerByIdAsync(Guid id)
    {
        return await _context.Employers.FindAsync(id);
    }

    public async Task<Employer> UpdateEmployerAsync(Employer employer)
    {
        _context.Employers.Update(employer);
        await _context.SaveChangesAsync();
        return employer;
    }

    public async Task DeleteEmployerAsync(Guid id)
    {
        var employer = await _context.Employers.FindAsync(id);
        if (employer != null)
        {
            _context.Employers.Remove(employer);
            await _context.SaveChangesAsync();
        }
    }
} 