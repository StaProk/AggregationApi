using Microsoft.AspNetCore.Mvc;
using AggregationService.Services;
using System.ComponentModel.DataAnnotations;


[Route("api/[controller]")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly NewsService _newsService;

    public NewsController(NewsService newsService)
    {
        _newsService = newsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetNews(string q = "", [FromQuery, Required] string sources = "", string from = "", string sortBy = "")
    {
        try
        {
            if (string.IsNullOrEmpty(sources))
            {
                return BadRequest("Sources are required.");
            }
            var result = await _newsService.GetNewsAsync(q, sources, from, sortBy);
            
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"An error occurred: {ex.Message}"});
        }
    }
}