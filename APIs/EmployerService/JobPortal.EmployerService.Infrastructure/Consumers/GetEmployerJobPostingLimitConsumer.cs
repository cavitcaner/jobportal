using JobPortal.Core.Events.EmployerEvents;
using JobPortal.EmployerService.Application.Interfaces;
using MassTransit;

namespace JobPortal.EmployerService.Infrastructure.Consumers;

public class GetEmployerJobPostingLimitConsumer : IConsumer<GetEmployerJobPostingLimitEventRequest>
{
    private readonly IEmployerService _employerService;

    public GetEmployerJobPostingLimitConsumer(IEmployerService employerService)
    {
        _employerService = employerService;
    }

    public async Task Consume(ConsumeContext<GetEmployerJobPostingLimitEventRequest> context)
    {
        var employer = await _employerService.GetEmployerByIdAsync(context.Message.EmployerId, CancellationToken.None);

        var response = new GetEmployerJobPostingLimitEventResponse
        {
            EmployerId = employer.Id,
            LimitOfJobPosting = employer.LimitOfJobPosts,
            CompanyName = employer.CompanyName
        };

        await context.RespondAsync(response);
    }
}
