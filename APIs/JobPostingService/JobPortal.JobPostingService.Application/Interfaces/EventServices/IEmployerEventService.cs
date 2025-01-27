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
        Task<int> GetEmployerJobPostingLimit(Guid employerId);
        Task SendJobPostCreatedEventAsync(JobPostCreatedEventRequest body);
    }
}
