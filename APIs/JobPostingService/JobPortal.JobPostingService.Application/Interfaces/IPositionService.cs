using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface IPositionService
    {
        Task CreatePositionAsync(Position position, CancellationToken cancellationToken);
        Task<Position> GetPositionByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ICollection<Position>> GetAllPositionsAsync(CancellationToken cancellationToken);
    }
} 