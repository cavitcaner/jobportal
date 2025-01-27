using MediatR;
using AutoMapper;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Application.DTOs;

namespace JobPortal.JobPostingService.Application.CQRS.Queries.Benefits
{
    public class GetBenefitListQuery : IRequest<List<ParamenterDto>>
    {
    }
    public class GetBenefitListQueryHandler : IRequestHandler<GetBenefitListQuery, List<ParamenterDto>>
    {
        private readonly IBenefitService _benefitService;
        private readonly IMapper _mapper;

        public GetBenefitListQueryHandler(IBenefitService benefitService, IMapper mapper)
        {
            _benefitService = benefitService;
            _mapper = mapper;
        }

        public async Task<List<ParamenterDto>> Handle(GetBenefitListQuery request, CancellationToken cancellationToken)
        {
            var benefits = await _benefitService.GetAllBenefitsAsync(cancellationToken);
            return _mapper.Map<List<ParamenterDto>>(benefits);
        }
    }
}