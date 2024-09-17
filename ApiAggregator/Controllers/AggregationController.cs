using Microsoft.AspNetCore.Mvc;
using AggregationService.Services;
using System.ComponentModel.DataAnnotations;

namespace AggregationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregationController : ControllerBase
    {
        private readonly NewsService _newsService;
        private readonly WeatherService _weatherService;
        private readonly TweetsService _tweeterService;

        public AggregationController(NewsService  newsService, WeatherService  weatherService, TweetsService tweeterService)
        {
            _newsService = newsService;
            _weatherService = weatherService;
            _tweeterService = tweeterService;
        }

        [HttpGet("aggregate")]
        public async Task<IActionResult> GetAggregatedData([FromQuery, Required] string hashtag, [FromQuery, Required] string userIdentifier, [FromQuery, Required] string keyword,[FromQuery, Required] string latitude = "", [FromQuery, Required] string longitude = "", string q = "", [FromQuery, Required] string sources = "", string from = "", string sortBy = "")
        {
            try
            {
                if (string.IsNullOrEmpty(hashtag) || string.IsNullOrEmpty(userIdentifier) || string.IsNullOrEmpty(keyword))
                {
                    return BadRequest("Hashtag, userIdentifier and keyword are required.");
                }
                if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
                {
                    return BadRequest("Latitude and longitude are required.");
                }
                if (string.IsNullOrEmpty(sources))
                {
                    return BadRequest("Sources are required.");
                }
                var newsTask = _newsService.GetNewsAsync(q, sources, from, sortBy);
                var weatherTask = _weatherService.GetWeatherAsync(latitude, longitude);
                var tweetesTask = _tweeterService.FetchTweetsAsync(hashtag, userIdentifier, keyword);

                await Task.WhenAll(newsTask, weatherTask, tweetesTask);

                return Ok(new {news = newsTask.Result, weather = weatherTask.Result, tweets = tweetesTask.Result});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}"});
            }
        }
    }
}