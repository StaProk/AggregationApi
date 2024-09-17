using Microsoft.AspNetCore.Mvc;
using AggregationService.Services;
using System.ComponentModel.DataAnnotations;

namespace AggregationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TweetsController : ControllerBase
    {
        private readonly TweetsService _tweetsService;

        public TweetsController(TweetsService tweetsService)
        {
            _tweetsService = tweetsService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchTweets([FromQuery, Required] string hashtag, [FromQuery, Required] string userIdentifier, [FromQuery, Required] string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(hashtag) || string.IsNullOrEmpty(userIdentifier) || string.IsNullOrEmpty(keyword))
                {
                    return BadRequest("Hashtag, userIdentifier and keyword are required.");
                }
                var tweets = await _tweetsService.FetchTweetsAsync(hashtag, userIdentifier, keyword);

                return Ok(tweets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}"});
            }
        }
    }
}
