using Microsoft.AspNetCore.Mvc;
using MediatR;
using JobPortal.EmployerService.Application.CQRS.Commands.Employer;
using JobPortal.EmployerService.Application.CQRS.Queries.Employer;

namespace JobPortal.EmployeringService.API.Controllers
{
    [ApiController]
    [Route("[controller]/employers")]
    public class EmployerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// creates a new jobpost data from request body
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateEmployerAsync(CreateEmployerCommand command, CancellationToken cancellation)
        {
            await _mediator.Send(command, cancellation);
            return Ok();
        }

        /// <summary>
        /// returns all employer data from elasticsearch
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployersAsync(CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetAllEmployersQuery(), cancellation));
        }

        /// <summary>
        /// returns a employer data with employer.id
        /// </summary>
        /// <param name="id">employer.id</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetEmployerAsync(Guid id, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetEmployerByIdQuery { Id = id }, cancellation));
        }

        /// <summary>
        /// updates employer
        /// </summary>
        /// <param name="id">employer.id</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPut("/{id}")]
        public async Task<IActionResult> UpdateEmployerAsync(Guid id, UpdateEmployerCommand command, CancellationToken cancellation)
        {
            command.Employer.Id = id;
            await _mediator.Send(command, cancellation);
            return Ok();
        }

        /// <summary>
        /// returns a employer details data with employer.id
        /// </summary>
        /// <param name="id">employer.id</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet("/{id}/details")]
        public async Task<IActionResult> GetEmployerDetailsAsync(Guid id, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetEmployerDetailsByIdQuery { Id = id }, cancellation));
        }
    }
}