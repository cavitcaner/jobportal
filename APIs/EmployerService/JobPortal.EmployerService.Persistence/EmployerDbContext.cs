using JobPortal.Core;
using JobPortal.EmployerService.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.EmployerService.Persistence;

public class EmployerDbContext : BaseDbContext
{
    public EmployerDbContext(DbContextOptions<EmployerDbContext> options) : base(options)
    {
    }

    public DbSet<Employer> Employers { get; set; }
} 