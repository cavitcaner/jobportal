using JobPortal.Core.Events.JobEvents;
using JobPortal.EmployerService.Application.CQRS.Commands.Employer;
using MassTransit;
using MediatR;
using System.Diagnostics;

namespace JobPortal.EmployerService.Infrastructure.Consumers;

public class JobPostCreatedEventConsumer : IConsumer<JobPostCreatedEventRequest>
{
    private readonly IMediator _mediator;

    public JobPostCreatedEventConsumer( IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<JobPostCreatedEventRequest> context)
    {
        var sw = new Stopwatch();
        sw.Start();
        var cancellationToken = new CancellationToken();
        try
        {
            await _mediator.Send(new DecreaseLimitEmployerCommand() { EmployerId = context.Message.EmployerId }, cancellationToken);
        }
        catch (Exception ex)
        {
            sw.Stop();
            await context.NotifyFaulted(sw.Elapsed, ToString(), ex);
            throw;
        }
        finally
        {
            sw.Stop();
        }

        await context.NotifyConsumed(sw.Elapsed, ToString());
    }
}