using JobPortal.Core.Events.EmployerEvents;
using JobPortal.Core.Events.JobEvents;
using JobPortal.JobPostingService.Application.Interfaces.EventServices;
using MassTransit;

namespace JobPortal.JobPostingService.Infrastructure
{

    public class EmployerEventService : IEmployerEventService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IBusControl _bus;

        public EmployerEventService(
            IPublishEndpoint publishEndpoint,
            IBusControl bus)
        {
            _publishEndpoint = publishEndpoint;
            _bus = bus;
        }

        public async Task<GetEmployerJobPostingLimitEventResponse> GetEmployerJobPostingLimit(Guid employerId)
        {
            var response = await _bus.Request<GetEmployerJobPostingLimitEventRequest, GetEmployerJobPostingLimitEventResponse>(new GetEmployerJobPostingLimitEventRequest
            {
                EmployerId = employerId
            });

            return response.Message;
        }

        public async Task SendJobPostCreatedEventAsync(JobPostCreatedEventRequest body)
        {
            await _publishEndpoint.Publish(body);
        }
    }
}