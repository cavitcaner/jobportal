using JobPortal.Core;
using JobPortal.Core.Configuration;
using JobPortal.Core.Model;
using JobPortal.JobPostingService.Domain.Entities;
using JobPortal.JobPostingService.Persistence.DataSeeds;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JobPortal.JobPostingService.Infrastructure.Persistence
{
    public class JobPostingDbContext : BaseDbContext
    {
        public JobPostingDbContext(DbContextOptions<JobPostingDbContext> options) : base(options)
        {
        }

        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<WorkingMethod> WorkingMethods { get; set; }
    }
}