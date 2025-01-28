using JobPortal.EmployerService.Domain.Entities;

namespace JobPortal.EmployerService.Application.Interfaces;

public interface IEmployerService
{
    /// <summary>
    /// Yeni oluşturulan yeni bir işveren kaydını db'ye ekler
    /// </summary>
    Task CreateEmployerAsync(Employer employer, CancellationToken cancellationToken);
    /// <summary>
    /// DB'de işveren listesini döner
    /// </summary>
    Task<ICollection<Employer>> GetAllEmployersAsync(CancellationToken cancellationToken);
    /// <summary>
    /// Belirli bir işveren bilgilerini db'den döner.
    /// </summary>
    Task<Employer?> GetEmployerByIdAsync(Guid id, CancellationToken cancellationToken);
    /// <summary>
    /// Belli bir işveren bilgilerini db seviyesinde günceller
    /// </summary>
    Task UpdateEmployerAsync(Employer employer, CancellationToken cancellationToken);
    /// <summary>
    /// Belli bir işveren bilgisini db'den siler
    /// </summary>
    Task DeleteEmployerAsync(Guid id, CancellationToken cancellationToken);
    /// <summary>
    /// Şirket adına ve telefon numarasına göre db'de arama yapar ve varsa işveren bilgisini döner
    /// </summary>
    Task<Employer?> GetEmployerByCompanyNameAndPhoneAsync(string companyName, string phoneNumber, CancellationToken cancellationToken);
    /// <summary>
    /// Veritabanında belirtilen şirket ismi ve telefon numarasına ait kayıt var mı diye kontrol eder. Varsa hata fırlatır.
    /// </summary>
    Task CheckIfExistsCompanyPhoneUniqueAsync(string companyName, string phoneNumber, CancellationToken cancellationToken);
}
