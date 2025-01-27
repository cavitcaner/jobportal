using JobPortal.JobPostingService.Domain.Entities;
namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface ICacheService<T>
    {
        Task<T?> GetAsync(string key);
        Task<List<T>?> GetListAsync(string key);
        Task RemoveAsync(string key);
        Task SetAsync(string key, List<T> value, TimeSpan expiration);

    }
}
