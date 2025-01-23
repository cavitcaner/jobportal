using JobPortal.JobPostingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.JobPostingService.Persistence.DataSeeds
{
    public class WorkingMethodSeedConfiguration : IEntityTypeConfiguration<WorkingMethod>
    {
        public void Configure(EntityTypeBuilder<WorkingMethod> builder)
        {
            builder.HasData(
                new WorkingMethod { Id = 1, Name = "Tam Zamanlı" },
                new WorkingMethod { Id = 2, Name = "Yarı Zamanlı" },
                new WorkingMethod { Id = 3, Name = "Uzaktan" },
                new WorkingMethod { Id = 4, Name = "Hibrit" },
                new WorkingMethod { Id = 5, Name = "Stajyer" },
                new WorkingMethod { Id = 6, Name = "Proje Bazlı" }
            );
        }
    }
}