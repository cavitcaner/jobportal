namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface ICacheService<T>
    {
        /// <summary>
        /// Cache'den belirilten keye göre data çekip döner.
        /// </summary>
        /// <returns></returns>
        Task<T?> GetAsync(string key);
        /// <summary>
        /// Cache'den belirilten keye göre dataları çekip döner. liste halinde atılan cache dataları için kullanılır
        /// </summary>
        /// <returns></returns>
        Task<List<T>?> GetListAsync(string key);
        /// <summary>
        /// Cache'den belirilten key'e ait dataları siler
        /// </summary>
        /// <returns></returns>
        Task RemoveAsync(string key);
        /// <summary>
        /// Cache'e belirtilen key'de ve expration tarihine göre kayıt ekler.
        /// </summary>
        /// <returns></returns>
        Task SetAsync(string key, List<T> value, TimeSpan expiration);

    }
}
