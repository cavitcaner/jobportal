using JobPortal.EmployerService.Application.Interfaces;
using MassTransit;

namespace JobPortal.EmployerService.Infrastructure.Consumers;

public class GetEmployerJobPostingLimitConsumer : IConsumer<GetEmployerJobPostingLimitRequest>
{
    private readonly IEmployerService _employerService;

    public GetEmployerJobPostingLimitConsumer(IEmployerService employerService)
    {
        _employerService = employerService;
    }

    public async Task Consume(ConsumeContext<GetEmployerJobPostingLimitRequest> context)
    {
        var employer = await _employerService.GetEmployerByIdAsync(context.Message.EmployerId, CancellationToken.None);

        var response = new GetEmployerJobPostingLimitResponse
        {
            EmployerId = employer.Id,
            LimitOfJobPosting = employer.LimitOfJobPosts
        };

        await context.RespondAsync(response);
    }
}
