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
    /// gönderilen işveren id'sine ait limiti azaltır
    /// </summary>
    public class DecreaseLimitEmployerCommand : IRequest
    {
        public Guid EmployerId { get; set; }
    }

    public class DecreaseLimitEmployerCommandHandler : IRequestHandler<DecreaseLimitEmployerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployerService _employerService;

        public DecreaseLimitEmployerCommandHandler(
            IUnitOfWork unitOfWork,
            IEmployerService employerService)
        {
            _unitOfWork = unitOfWork;
            _employerService = employerService;
        }

        public async Task Handle(DecreaseLimitEmployerCommand request, CancellationToken cancellationToken)
        {
            var employer = await _employerService.GetEmployerByIdAsync(request.EmployerId, cancellationToken);
            employer.LimitOfJobPosts--;
            await _employerService.UpdateEmployerAsync(employer, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }

    public class DecreaseLimitEmployerCommandValidator : AbstractValidator<DecreaseLimitEmployerCommand>
    {
        public DecreaseLimitEmployerCommandValidator()
        {
            RuleFor(x => x.EmployerId)
                .Must(x => x != Guid.Empty).WithMessage("İşveren Id alanı boş olamaz.");
        }
    }
}