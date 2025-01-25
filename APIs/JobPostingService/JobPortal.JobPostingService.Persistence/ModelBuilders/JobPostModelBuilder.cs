using JobPortal.Core.Configuration;
using JobPortal.JobPostingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.JobPostingService.Persistence.ModelBuilders
{
    public class JobPostModelBuilder : AModelBuilder
    {
        public override void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobPost>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(2000);
                entity.Property(e => e.EmployerId).IsRequired();
                entity.Property(e => e.Requirements).IsRequired(false).HasMaxLength(250);
                entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(150);
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.ExpirationDate).IsRequired();
                entity.Property(e => e.Salary).IsRequired(false);
                entity.Property(e => e.PositionId).IsRequired(false);
                entity.HasMany(e => e.Benefits).WithMany().UsingEntity("PostBenefits");
                entity.Property(e => e.WorkingMethodId).IsRequired(false);
                entity.Property(e => e.IsDeleted).IsRequired(false).HasDefaultValue(false);
            });
        }
    }
}
