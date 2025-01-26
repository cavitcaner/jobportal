using AutoMapper;
using FluentValidation;
using JobPortal.Core.Helpers;
using JobPortal.Core.Repository;
using JobPortal.Core.UnitOfWork;
using JobPortal.EmployerService.Application.DTOs;
using JobPortal.EmployerService.Application.Interfaces;
using MediatR;

namespace JobPortal.EmployerService.Application.CQRS.Commands.Employer
{
    /// <summary>
    /// gönderilen bilgiler ile eşleşen kaydı günceller
    /// </summary>
    public class UpdateEmployerCommand : IRequest<Guid>
    {
        public UpdateEmployerRequestDto Employer { get; set; }
    }

    public class UpdateEmployerCommandHandler : IRequestHandler<UpdateEmployerCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployerService _employerService;

        public UpdateEmployerCommandHandler(
            IUnitOfWork unitOfWork,
            IEmployerService employerService)
        {
            _unitOfWork = unitOfWork;
            _employerService = employerService;
        }

        public async Task<Guid> Handle(UpdateEmployerCommand request, CancellationToken cancellationToken)
        {
            var employer = await _employerService.GetEmployerByIdAsync(request.Employer.Id, cancellationToken);

            ExceptionHelper.ThrowIfNullOrEmpty(employer, "İşveren bilgisi bulunamadı!");

            employer.PhoneNumber = request.Employer.PhoneNumber;
            employer.Address = request.Employer.Address;
            employer.CompanyName = request.Employer.CompanyName;
            employer.LimitOfJobPosts = request.Employer.LimitOfJobPosts ?? employer.LimitOfJobPosts;

            await _employerService.UpdateEmployerAsync(employer, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return employer.Id;
        }
    }

    public class UpdateEmployerCommandValidator : AbstractValidator<UpdateEmployerCommand>
    {
        public UpdateEmployerCommandValidator()
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
        }
    }
}