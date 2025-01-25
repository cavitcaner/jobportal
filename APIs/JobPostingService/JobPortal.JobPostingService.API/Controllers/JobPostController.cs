using JobPortal.JobPostingService.Application.CQRS.Queries.JobPost;
using JobPortal.JobPostingService.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using JobPortal.JobPostingService.Application.CQRS.Commands.JobPost;

namespace JobPortal.JobPostingService.API.Controllers
{
    [ApiController]
    [Route("[controller]/jobs")]
    public class JobPostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobPostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// returns postjobs data from elasticsearch with query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost("search")]
        public async Task<IActionResult> SearchJobPostAsync(SearchJobPostsQuery query, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(query, cancellation));
        }

        /// <summary>
        /// creates a new jobpost data from request body
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateJobPostAsync(CreateJobPostCommand command, CancellationToken cancellation)
        {
            await _mediator.Send(command, cancellation);
            return Ok();
        }

        /// <summary>
        /// returns all postjobs data from elasticsearch
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllJobPostsAsync(CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetAllJobPostsQuery(), cancellation));
        }

        /// <summary>
        /// returns a postjob data from elasticsearch with postjob.id
        /// </summary>
        /// <param name="id">postjob.id</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobPostAsync(Guid id, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetJobPostByIdQuery { Id = id }, cancellation));
        }

        /// <summary>
        /// updates a new jobpost data from request body
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateJobPostAsync(UpdateJobPostCommand command, CancellationToken cancellation)
        {
            await _mediator.Send(command, cancellation);
            return Ok();
        }
    }
}