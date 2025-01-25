using JobPortal.Core.Repository;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Domain.Entities;
using System.Threading;

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

        public async Task<Position> GetPositionByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<ICollection<Position>> GetAllPositionsAsync(CancellationToken cancellationToken)
        {
            return await _genericRepository.GetAllAsync(cancellationToken);
        }
    }
} 