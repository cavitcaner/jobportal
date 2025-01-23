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

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}