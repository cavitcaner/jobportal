namespace JobPortal.Core.Repository
{
    public interface IRedisRepository<T>
    {
        Task<T> GetAsync(string key);
        Task SetAsync(string key, T value, TimeSpan expiration);
        Task RemoveAsync(string key);
    }

}
