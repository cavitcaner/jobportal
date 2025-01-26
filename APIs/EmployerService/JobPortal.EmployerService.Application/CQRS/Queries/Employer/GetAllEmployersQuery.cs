using MediatR;
using AutoMapper;
using JobPortal.EmployerService.Application.DTOs;
using JobPortal.EmployerService.Application.Interfaces;

namespace JobPortal.EmployerService.Application.CQRS.Queries.Employer
{
    /// <summary>
    /// ilan süresi henüz dolmamýþ bütün ilan listesini döner
    /// </summary>
    public class GetAllEmployersQuery : MediatR.IRequest<List<GetEmployerResponseDto>>
    {
    }

    public class GetAllEmployersQueryHandler : IRequestHandler<GetAllEmployersQuery, List<GetEmployerResponseDto>>
    {
        private readonly IEmployerService _employerService;
        private readonly IMapper _mapper;

        public GetAllEmployersQueryHandler(IMapper mapper, IEmployerService employerService)
        {
            _mapper = mapper;
            _employerService = employerService;
        }

        public async Task<List<GetEmployerResponseDto>> Handle(GetAllEmployersQuery request, CancellationToken cancellationToken)
        {
            var employers = await _employerService.GetAllEmployersAsync(cancellationToken);
            return _mapper.Map<List<GetEmployerResponseDto>>(employers);
        }
    }
}