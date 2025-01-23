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
                new Benefit { Id = 1, Name = "Özel Sağlık Sigortası" },
                new Benefit { Id = 2, Name = "Yemek Kartı" },
                new Benefit { Id = 3, Name = "Servis" },
                new Benefit { Id = 4, Name = "Esnek Çalışma Saatleri" },
                new Benefit { Id = 5, Name = "Uzaktan Çalışma" },
                new Benefit { Id = 6, Name = "Yıllık İzin" },
                new Benefit { Id = 7, Name = "Eğitim Desteği" }
            );
        }
    }
} 