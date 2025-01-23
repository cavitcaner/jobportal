using MediatR;

namespace JobPortal.JobPostingService.Application.Features.Benefits.Queries.GetBenefitList
{
    public class GetBenefitListQuery : IRequest<List<BenefitListDto>>
    {
    }
} 