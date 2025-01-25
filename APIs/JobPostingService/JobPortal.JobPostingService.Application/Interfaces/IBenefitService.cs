using JobPortal.JobPostingService.Domain.Entities;
namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface IBenefitService
    {
        Task CreateBenefitAsync(Benefit benefit, CancellationToken cancellationToken);
        Task<Benefit> GetBenefitByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ICollection<Benefit>> GetAllBenefitsAsync(CancellationToken cancellationToken);
    }
}
