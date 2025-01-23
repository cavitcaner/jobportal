using MediatR;
using AutoMapper;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Application.DTOs;

namespace JobPortal.JobPostingService.Application.Features.Benefits.Queries.GetBenefitList
{
    public class GetBenefitListQuery : IRequest<List<BenefitDto>>
    {
    }
    public class GetBenefitListQueryHandler : IRequestHandler<GetBenefitListQuery, List<BenefitDto>>
    {
        private readonly IBenefitService _benefitService;
        private readonly IMapper _mapper;

        public GetBenefitListQueryHandler(IBenefitService benefitService, IMapper mapper)
        {
            _benefitService = benefitService;
            _mapper = mapper;
        }

        public async Task<List<BenefitDto>> Handle(GetBenefitListQuery request, CancellationToken cancellationToken)
        {
            var benefits = await _benefitService.GetAllBenefitsAsync();
            return _mapper.Map<List<BenefitDto>>(benefits);
        }
    }
} 