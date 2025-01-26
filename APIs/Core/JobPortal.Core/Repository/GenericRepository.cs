using JobPortal.Core.Model;
using JobPortal.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobPortal.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        
        public async Task<ICollection<T>> GetWithQueryAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(expression).ToListAsync(cancellationToken);
        }

        public async Task<bool> AnyWithQueryAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(expression, cancellationToken);
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Add<T>(entity);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await GetByIdAsync(id, cancellationToken);
        }
        
        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Remove<T>(entity);
        }

        public async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.FindAsync<T>(id, cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(entity);
        }
    }
}
