using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace JobPortal.JobPostingService.Application.Features.Benefits.Queries.GetBenefitList
{
    public class GetBenefitListQueryHandler : IRequestHandler<GetBenefitListQuery, List<BenefitListDto>>
    {
        private readonly  _context;
        private readonly IMapper _mapper;

        public GetBenefitListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BenefitListDto>> Handle(GetBenefitListQuery request, CancellationToken cancellationToken)
        {
            var benefits = await _context.Benefits.ToListAsync(cancellationToken);
            return _mapper.Map<List<BenefitListDto>>(benefits);
        }
    }
} 