using JobPortal.Core.Configuration;
using JobPortal.EmployerService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.EmployerService.Persistence.ModelBuilders
{
    public class EmployerModelBuilder : AModelBuilder
    {
        public override void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employer>(builder =>
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.CompanyName).IsRequired();
                builder.Property(e => e.Address).IsRequired();
                builder.Property(e => e.LimitOfJobPosts).IsRequired();
                builder.Property(e => e.PhoneNumber).IsRequired();
                builder.HasKey(x => new { x.PhoneNumber, x.CompanyName });
            });
        }
    }
}
