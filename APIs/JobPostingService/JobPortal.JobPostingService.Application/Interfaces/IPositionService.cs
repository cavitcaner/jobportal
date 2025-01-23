using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface IPositionService
    {
        Task CreatePositionAsync(Position position, CancellationToken cancellationToken);
        Task<Position> GetPositionByIdAsync(Guid id);
        Task<ICollection<Position>> GetAllPositionsAsync();
    }
} 