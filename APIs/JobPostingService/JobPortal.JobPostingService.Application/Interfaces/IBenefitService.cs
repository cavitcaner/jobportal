using JobPortal.JobPostingService.Domain.Entities;
namespace JobPortal.JobPostingService.Application.Interfaces
{
    public interface IBenefitService
    {
        /// <summary>
        /// yeni bir Yan hak oluştururak db'ye kayıt yapar
        /// </summary>
        /// <returns></returns>
        Task CreateBenefitAsync(Benefit benefit, CancellationToken cancellationToken);
        /// <summary>
        /// Belirli bir yan hak bilgisini db'den çekip döner.
        /// </summary>
        /// <returns></returns>
        Task<Benefit> GetBenefitByIdAsync(Guid id, CancellationToken cancellationToken);
        /// <summary>
        /// Yan haklar listesini db'den alıp döner.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Benefit>> GetAllBenefitsAsync(CancellationToken cancellationToken);
    }
}
