using JobPortal.Core.Configuration;
using JobPortal.JobPostingService.Domain.Entities;
using JobPortal.JobPostingService.Persistence.DataSeeds;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.JobPostingService.Persistence.ModelBuilders
{
    public class WorkingMethodModelBuilder : AModelBuilder
    {
        public override void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkingMethod>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });
            modelBuilder.ApplyConfiguration(new WorkingMethodSeedConfiguration());
        }
    }
}
