using JobPortal.Core.Repository;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Infrastructure.Services
{
    public class BenefitService : IBenefitService
    {
        private readonly IGenericRepository<Benefit> _genericRepository;
        public BenefitService(IGenericRepository<Benefit> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task CreateBenefitAsync(Benefit benefit, CancellationToken cancellationToken)
        {
            await _genericRepository.AddAsync(benefit, cancellationToken);
        }

        public async Task<Benefit> GetBenefitByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<ICollection<Benefit>> GetAllBenefitsAsync(CancellationToken cancellationToken)
        {
            return await _genericRepository.GetAllAsync(cancellationToken);
        }
    }
}
