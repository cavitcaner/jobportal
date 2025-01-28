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
        /// <summary>
        /// Veritabanında query'e göre arama yapar
        /// </summary>
        Task<ICollection<T>> GetWithQueryAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        /// <summary>
        /// Veritabanında query'e göre kayıt var mı yok mu bilgisini döner
        /// </summary>
        Task<bool> AnyWithQueryAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        /// <summary>
        /// Belirli bir id'ye göre veritabanından kayıt döner
        /// </summary>
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        /// <summary>
        /// İlgili tipteki bütün kayıtları döner
        /// </summary>
        Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken);
        /// <summary>
        /// İlgili tipte yeni kayıt oluşturur.
        /// </summary>
        Task AddAsync(T entity, CancellationToken cancellationToken);
        /// <summary>
        /// Belirtilen Db'deki bir kaydı günceller
        /// </summary>
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        /// <summary>
        /// Belirtilen Id'ye ait Db'deki bir kaydı siler
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        /// <summary>
        /// Belirtilen Db'deki bir kaydı siler
        /// </summary>
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
