using JobPortal.Core.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Core.Configuration;
using System.Reflection;

namespace JobPortal.Core
{
    public abstract class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        private static void CheckEntities(ICollection<EntityEntry> entityEntries)
        {
            foreach (var entity in entityEntries)
            {
                var baseEntity = entity.Entity as BaseEntity;
                switch (entity.State)
                {
                    case EntityState.Deleted:
                        if (entity.Entity is ISoftDeletable deletableEntity)
                        {
                            deletableEntity.DeletedDate = DateTime.Now;
                            deletableEntity.IsDeleted = true;
                            entity.State = EntityState.Modified;
                        }
                        break;
                    case EntityState.Added:
                        if (baseEntity != null)
                            baseEntity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        if (baseEntity != null)
                            baseEntity.UpdatedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
        }
        public override int SaveChanges()
        {
            CheckEntities(ChangeTracker.Entries().ToList());
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            CheckEntities(ChangeTracker.Entries().ToList());
            return base.SaveChangesAsync(cancellationToken);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            CheckEntities(ChangeTracker.Entries().ToList());
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            CheckEntities(ChangeTracker.Entries().ToList());
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelBuilderTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(AModelBuilder)))
                .ToList();

            foreach (var modelBuilderType in modelBuilderTypes)
            {
                var modelBuilderInstance = Activator.CreateInstance(modelBuilderType) as AModelBuilder;
                modelBuilderInstance?.Build(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
