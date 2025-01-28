using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface IPositionService
    {
        /// <summary>
        /// Veritabanına yeni bir pozisyon ekler
        /// </summary>
        /// <returns></returns>
        Task CreatePositionAsync(Position position, CancellationToken cancellationToken);
        /// <summary>
        /// Veritabanından belirli bir pozisyon bilgisini döner
        /// </summary>
        /// <returns></returns>
        Task<Position> GetPositionByIdAsync(Guid id, CancellationToken cancellationToken);
        /// <summary>
        /// Veritabanından bütün pozisyon listesini döner
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Position>> GetAllPositionsAsync(CancellationToken cancellationToken);
    }
} 
