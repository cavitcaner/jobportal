using JobPortal.Core.Events.JobEvents;
using JobPortal.JobPostingService.Application.Interfaces.EventServices;
using MassTransit;

public class EmployerEventService : IEmployerEventService
{
    private readonly IRequestClient<GetEmployerJobPostingLimitEventRequest> _client;
    private readonly IPublishEndpoint _publishEndpoint;

    public EmployerEventService(
        IRequestClient<GetEmployerJobPostingLimitEventRequest> client,
        IPublishEndpoint publishEndpoint)
    {
        _client = client;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<int> GetEmployerJobPostingLimit(Guid employerId)
    {
        var response = await _client.GetResponse<GetEmployerJobPostingLimitEventResponse>(new GetEmployerJobPostingLimitEventRequest 
        { 
            EmployerId = employerId 
        });

        return response.Message.LimitOfJobPosting;
    }

    public async Task SendJobPostCreatedEventAsync(JobPostCreatedEventRequest body)
    {
        await _publishEndpoint.Publish(body);
    }
} 