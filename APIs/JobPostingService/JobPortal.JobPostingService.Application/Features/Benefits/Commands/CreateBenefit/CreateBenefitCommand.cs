using MediatR;

namespace JobPortal.JobPostingService.Application.Features.Benefits.Commands.CreateBenefit
{
    public class CreateBenefitCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
} 