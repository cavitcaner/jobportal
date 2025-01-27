using JobPortal.Core.Events.EmployerEvents;
using JobPortal.Core.Events.JobEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.JobPostingService.Application.Interfaces.EventServices
{

    public interface IEmployerEventService
    {
        Task<GetEmployerJobPostingLimitEventResponse> GetEmployerJobPostingLimit(Guid employerId);
        Task SendJobPostCreatedEventAsync(JobPostCreatedEventRequest body);
    }
}
