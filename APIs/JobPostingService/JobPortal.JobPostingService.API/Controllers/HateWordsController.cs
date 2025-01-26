using JobPortal.JobPostingService.Infrastructure.Cache.Redis;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.JobPostingService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/hate-words")]
    public class HateWordsController : ControllerBase
    {
        private readonly HateWordsRedisService _hateWordsRedisService;

        public HateWordsController(HateWordsRedisService hateWordsRedisService)
        {
            _hateWordsRedisService = hateWordsRedisService;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetHateWords()
        {
            var hateWords = await _hateWordsRedisService.GetListAsync();
            if (hateWords == null || !hateWords.Any())
                return NotFound("No hate words found in Redis.");

            return Ok(hateWords);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHateWords([FromBody] List<string> hateWords)
        {
            if (hateWords == null || !hateWords.Any())
                return BadRequest("Hate words list cannot be empty.");

            hateWords = hateWords
                .Select(w => w.Trim().ToLowerInvariant())
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Distinct()
                .ToList();

            await _hateWordsRedisService.SetAsync(hateWords, TimeSpan.FromDays(365));

            return Ok(new 
            { 
                Message = "Hate words successfully saved", 
                Count = hateWords.Count,
                Words = hateWords 
            });
        }
    }
} 