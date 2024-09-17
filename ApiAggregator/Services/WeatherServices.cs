using Newtonsoft.Json;
using AggregationService.Models;

namespace AggregationService.Services
{
    public class WeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _weatherApiKey;

        public WeatherService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _weatherApiKey = configuration["ApiSettings:OpenWeatherMapApiKey"] 
                ?? throw new ArgumentNullException("OpenWeatherMapApiKey is not configured in appsettings.json");
        }
        public async Task<List<WeatherInfo>> GetWeatherAsync(string latitude, string longitude)
        {
            var client = _httpClientFactory.CreateClient();
            
            var response = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&appid={_weatherApiKey}");
            
            WeatherResponse? weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            if(weatherResponse == null) throw new Exception("Error: no weather data was aggregated");
            if (weatherResponse.Cod != "200") throw new Exception($"Error: {weatherResponse.Message}");

            return weatherResponse.List;
        }
    }
}