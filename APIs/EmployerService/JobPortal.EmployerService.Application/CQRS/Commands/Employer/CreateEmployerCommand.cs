using AutoMapper;
using FluentValidation;
using JobPortal.Core.Helpers;
using JobPortal.Core.Statics;
using JobPortal.Core.UnitOfWork;
using JobPortal.EmployerService.Application.DTOs;
using JobPortal.EmployerService.Application.Interfaces;
using MediatR;

namespace JobPortal.EmployerService.Application.CQRS.Commands.Employer
{
    /// <summary>
    /// gönderilen bilgiler ile yeni bir işveren kaydı oluşturur
    /// </summary>
    public class CreateEmployerCommand : IRequest<Guid>
    {
        public CreateEmployerRequestDto Employer { get; set; }
    }

    public class CreateEmployerCommandHandler : IRequestHandler<CreateEmployerCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmployerService _employerService;

        public CreateEmployerCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IEmployerService employerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _employerService = employerService;
        }

        public async Task<Guid> Handle(CreateEmployerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _employerService.CheckIfExistsCompanyPhoneUniqueAsync(request.Employer.CompanyName, request.Employer.PhoneNumber, cancellationToken);
                var employer = _mapper.Map<Domain.Entities.Employer>(request.Employer);
                employer.LimitOfJobPosts = (short)EmployerStatics.DefaultLimitOfJobPosts;
                await _employerService.CreateEmployerAsync(employer, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return employer.Id;
            }
            catch (Exception ex)
            {
                //CreateEmployerRejected(ex.Message)
                throw;
            }
        }
    }


    public class CreateEmployerCommandValidator : AbstractValidator<CreateEmployerCommand>
    {
        public CreateEmployerCommandValidator()
        {
            RuleFor(x => x.Employer.CompanyName)
                .NotEmpty().WithMessage("Şirket adı boş olamaz.")
                .MaximumLength(250).WithMessage("Şirket adı 250 karakterden uzun olamaz.");

            RuleFor(x => x.Employer.Address)
                .NotEmpty().WithMessage("Adres alanı boş olamaz.")
                .MaximumLength(500).WithMessage("Adres 500 karakterden uzun olamaz.");

            RuleFor(x => x.Employer.PhoneNumber)
                .NotEmpty().WithMessage("Telefon bilgisi boş olamaz.")
                .MaximumLength(15).WithMessage("Telefon bilgisi 15 karakterden uzun olamaz.");

            RuleFor(x => x.Employer.IdentityRefId)
                .Must(x => x != Guid.Empty).WithMessage("Identity RefId alanı boş olamaz."); ;
        }
    }
}