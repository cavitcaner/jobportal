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
                new Position { Id = Guid.Parse("81b645c8-f5a5-4568-a556-6364e6ec3b26"), Name = "Yazılım Geliştirici" },
                new Position { Id = Guid.Parse("13ff991b-ccbc-4438-9892-0a33ca338950"), Name = "Kıdemli Yazılım Geliştirici" },
                new Position { Id = Guid.Parse("d103c194-052a-4796-bd1b-81d70dc87101"), Name = "İş Analisti" },
                new Position { Id = Guid.Parse("d76aef2d-2666-4f0f-9ab8-29b3b64bc241"), Name = "Proje Yöneticisi" },
                new Position { Id = Guid.Parse("b3357633-d0e4-4360-8cf6-322f3cc2a373"), Name = "DevOps Mühendisi" },
                new Position { Id = Guid.Parse("886fe6a0-41ee-4091-af37-b47f44bb93e4"), Name = "UI/UX Tasarımcı" },
                new Position { Id = Guid.Parse("26c5c218-8b8e-4c77-b2d3-0a4e3258ee15"), Name = "Test Mühendisi" }
            );
        }
    }
} 