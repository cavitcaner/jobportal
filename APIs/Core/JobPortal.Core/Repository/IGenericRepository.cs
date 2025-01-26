using JobPortal.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Core.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task<ICollection<T>> GetWithQueryAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task<bool> AnyWithQueryAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
