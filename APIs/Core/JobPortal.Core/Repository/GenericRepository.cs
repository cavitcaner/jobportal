using JobPortal.Core.Model;
using JobPortal.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly DbContext _dbContext;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Add<T>(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id);
            await DeleteAsync(entity, cancellationToken);
        }
        
        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Remove<T>(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
