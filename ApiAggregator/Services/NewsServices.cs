using NewsAPI;
using NewsAPI.Models;  
using NewsAPI.Constants;

namespace AggregationService.Services
{
    public class NewsService
    {
        private readonly string _newsApiKey;

        public NewsService(IConfiguration configuration)
        {
            _newsApiKey = configuration["ApiSettings:NewsApiKey"] 
                ?? throw new ArgumentNullException("NewsApiKey is not configured in appsettings.json");
        }
        public async Task<List<Article>> GetNewsAsync(string q, string sources, string from, string sortBy)
        {
            var newsApiClient = new NewsApiClient(_newsApiKey);

            var request = new EverythingRequest
            {
                Q = null,
                Sources = null,
                From = DateTime.Today,
                SortBy = (SortBys)Enum.Parse(typeof(SortBys), "publishedAt", true)
            };

            if(q != "") request.Q = q;
            
            if(sources != "") request.Sources = sources?.Split(',').ToList();

            if(from != "") request.From = DateTime.Parse(from);

            if(sortBy != "") request.SortBy = (SortBys)Enum.Parse(typeof(SortBys), sortBy, true);
            
            var response = await newsApiClient.GetEverythingAsync(request);

            if (response.Status == Statuses.Error)
            {
                throw new Exception($"Error fetching news: {response.Error.Message}");
            }        

            return response.Articles; 
        }
    }
}