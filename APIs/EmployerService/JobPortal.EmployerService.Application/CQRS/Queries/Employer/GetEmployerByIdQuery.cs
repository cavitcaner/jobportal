using MediatR;
using AutoMapper;
using JobPortal.EmployerService.Application.DTOs;
using JobPortal.EmployerService.Application.Interfaces;
using JobPortal.Core.Helpers;

namespace JobPortal.EmployerService.Application.CQRS.Queries.Employer
{
    /// <summary>
    /// belirli bir iþveren bilgisini döner
    /// </summary>
    public class GetEmployerByIdQuery : MediatR.IRequest<GetEmployerResponseDto>
    {
        public Guid Id { get; set; }
    }

    public class GetEmployerByIdQueryHandler : IRequestHandler<GetEmployerByIdQuery, GetEmployerResponseDto>
    {
        private readonly IEmployerService _employerService;
        private readonly IMapper _mapper;

        public GetEmployerByIdQueryHandler(IMapper mapper, IEmployerService employerService)
        {
            _mapper = mapper;
            _employerService = employerService;
        }

        public async Task<GetEmployerResponseDto> Handle(GetEmployerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _employerService.GetEmployerByIdAsync(request.Id, cancellationToken);
            ExceptionHelper.ThrowIfNullOrEmpty(result, "Ýþveren bilgisi bulunamadý.");
            return _mapper.Map<GetEmployerResponseDto>(result);
        }
    }
}