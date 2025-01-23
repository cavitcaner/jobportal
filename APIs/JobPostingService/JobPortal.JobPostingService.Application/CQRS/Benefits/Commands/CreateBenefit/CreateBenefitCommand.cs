using MediatR;

namespace JobPortal.JobPostingService.Application.Features.Benefits.Commands.CreateBenefit
{
    public class CreateBenefitCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
} 