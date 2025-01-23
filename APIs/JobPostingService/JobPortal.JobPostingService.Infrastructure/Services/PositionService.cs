using JobPortal.Core.Repository;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Infrastructure.Services
{
    public class PositionService : IPositionService
    {
        private readonly IGenericRepository<Position> _genericRepository;
        public PositionService(IGenericRepository<Position> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task CreatePositionAsync(Position position, CancellationToken cancellationToken)
        {
            await _genericRepository.AddAsync(position, cancellationToken);
        }

        public async Task<Position> GetPositionByIdAsync(Guid id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<ICollection<Position>> GetAllPositionsAsync()
        {
            return await _genericRepository.GetAllAsync();
        }
    }
} 