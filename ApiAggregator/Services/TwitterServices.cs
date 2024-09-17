using System.Net.Http.Headers;
using AggregationService.Models;
using Newtonsoft.Json;

namespace AggregationService.Services
{
    public class TweetsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _bearerToken;

        public TweetsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _bearerToken = configuration["TwitterApi:BearerToken"]
                ?? throw new ArgumentNullException("BearerToken is not configured in appsettings.json");
        }

        public async Task<List<TweetData>> FetchTweetsAsync(string hashtag, string userIdentifier, string keyword)
        {
            var query = Uri.EscapeDataString($"#{hashtag} from:{userIdentifier} {keyword}");
            var url = $"https://api.twitter.com/2/tweets/search/recent?query={query}";

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);

            try
            {
                var response = await _httpClient.SendAsync(requestMessage);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error Content: {errorContent}");
                }

                var content = await response.Content.ReadAsStringAsync();
                var tweetsContent = JsonConvert.DeserializeObject<TweetResponse>(content);
                if ((tweetsContent == null) || (tweetsContent.Data == null))
                {
                    throw new Exception("No tweets returned");
                }

                return tweetsContent.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occurred: {ex.Message}");
            }
        }
    }
}
