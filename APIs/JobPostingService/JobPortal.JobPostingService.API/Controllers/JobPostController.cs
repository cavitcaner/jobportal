using JobPortal.JobPostingService.Application.DTOs;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.JobPostingService.API.Controllers
{
    [ApiController]
    [Route("[controller]/jobs")]
    public class JobPostController : ControllerBase
    {
        private readonly ILogger<JobPostController> _logger;

        public JobPostController(ILogger<JobPostController> logger)
        {
            _logger = logger;
        }

        //[HttpGet("search")]
        //public async Task<ICollection<JobPostResponseDto>> SearchJobPostAsync()
        //{

        //}
    }
}