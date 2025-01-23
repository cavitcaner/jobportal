using JobPortal.JobPostingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.JobPostingService.Persistence.DataSeeds
{
    public class PositionSeedConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasData(
                new Position { Id = 1, Name = "Yazılım Geliştirici" },
                new Position { Id = 2, Name = "Kıdemli Yazılım Geliştirici" },
                new Position { Id = 3, Name = "İş Analisti" },
                new Position { Id = 4, Name = "Proje Yöneticisi" },
                new Position { Id = 5, Name = "DevOps Mühendisi" },
                new Position { Id = 6, Name = "UI/UX Tasarımcı" },
                new Position { Id = 7, Name = "Test Mühendisi" }
            );
        }
    }
} 