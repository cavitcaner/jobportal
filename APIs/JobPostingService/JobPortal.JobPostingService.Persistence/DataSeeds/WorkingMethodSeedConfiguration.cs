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
                new WorkingMethod { Id = Guid.Parse("1da27eef-d85c-41cb-9a89-af5881f3a5c1"), Name = "Tam Zamanlı" },
                new WorkingMethod { Id = Guid.Parse("b47aef00-3343-4436-9d7f-d52683ce4cf6"), Name = "Yarı Zamanlı" },
                new WorkingMethod { Id = Guid.Parse("9f930531-9ef9-4d3e-bb49-0ae2bf8129d3"), Name = "Uzaktan" },
                new WorkingMethod { Id = Guid.Parse("a6f5f822-51cc-4701-a7c2-eb25d47c9ae5"), Name = "Hibrit" },
                new WorkingMethod { Id = Guid.Parse("22636d32-03f2-45ff-9519-b8b164fc39b2"), Name = "Stajyer" },
                new WorkingMethod { Id = Guid.Parse("08a6ecee-2c9e-4939-b2ae-2cb1f8a27ac2"), Name = "Proje Bazlı" }
            );
        }
    }
}