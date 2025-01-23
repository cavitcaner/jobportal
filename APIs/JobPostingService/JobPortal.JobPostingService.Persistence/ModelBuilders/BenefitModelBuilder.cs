using JobPortal.Core.Configuration;
using JobPortal.JobPostingService.Domain.Entities;
using JobPortal.JobPostingService.Persistence.DataSeeds;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.JobPostingService.Persistence.ModelBuilders
{
    public class BenefitModelBuilder : AModelBuilder
    {
        public override void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });
        }
    }
}
