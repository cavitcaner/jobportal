using JobPortal.Core.Events.EmployerEvents;
using JobPortal.Core.Events.JobEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.JobPostingService.Application.Interfaces.EventServices
{
    
    /// <summary>
    /// Kuyrukla ilgili metodları bulundurur
    /// </summary>
    public interface IEmployerEventService
    {
         /// <summary>
        /// Bir işverenin ilan yayınlama limitini ve şirket adını dönen event metodudur
        /// </summary>
        /// <param name="employerId">İşveren Id</param>
        /// <returns>Şirket adı ve ilan yayınlama limitini döner</returns>
        Task<GetEmployerJobPostingLimitEventResponse> GetEmployerJobPostingLimit(Guid employerId);
        
        /// <summary>
        /// Bir ilan oluşturulduğunda ilanı oluşturan işverenin limitini düşürmek için bir event fırlatır.
        /// </summary>
        /// <returns></returns>
        Task SendJobPostCreatedEventAsync(JobPostCreatedEventRequest body);
    }
}
