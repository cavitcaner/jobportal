using JobPortal.JobPostingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.JobPostingService.Persistence.DataSeeds
{
    public class BenefitSeedConfiguration : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            builder.HasData(
                new Benefit { Id = Guid.Parse("f1781e55-1a1e-4506-8462-e46f2602f0fa"), Name = "Özel Sağlık Sigortası" },
                new Benefit { Id = Guid.Parse("846fe540-1e2a-410a-b96b-9125cef65d30"), Name = "Yemek Kartı" },
                new Benefit { Id = Guid.Parse("7d461f4b-7433-4290-9739-62d2c7d0e1cc"), Name = "Servis" },
                new Benefit { Id = Guid.Parse("92209f09-387a-49dc-be08-9c5e092b8f72"), Name = "Esnek Çalışma Saatleri" },
                new Benefit { Id = Guid.Parse("6fd71369-623d-42ad-b1b7-bb7c0fb9807b"), Name = "Uzaktan Çalışma" },
                new Benefit { Id = Guid.Parse("53c068c9-f42b-41e7-ba66-3042fa76d8ea"), Name = "Yıllık İzin" },
                new Benefit { Id = Guid.Parse("97ac4390-ee4c-405c-9dfb-d0ceed7cddd0"), Name = "Eğitim Desteği" }
            );                                 
        }
    }
} 