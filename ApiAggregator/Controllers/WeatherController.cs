using Microsoft.AspNetCore.Mvc;
using AggregationService.Services;
using System.ComponentModel.DataAnnotations;


[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetWeather([FromQuery, Required] string latitude = "", [FromQuery, Required] string longitude = "")
    {
        try
        {
            if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
            {
                return BadRequest("Latitude and longitude are required.");
            }
            var result = await _weatherService.GetWeatherAsync(latitude, longitude);
            
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"An error occurred: {ex.Message}"});
        }
    }
}