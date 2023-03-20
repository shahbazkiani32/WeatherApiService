
using Newtonsoft.Json;
using WeatherApiService.Models;

namespace WeatherApiService;

public class WeatherService
{
    HttpClient _client;
    ILogger _logger;
    public WeatherService(ILogger logger)
    {
        _client = new HttpClient();
        _logger = logger;
    }
    public async Task<WeatherData> GetWeatherData(string query)
    {
        WeatherData weatherData = null;
        try
        {
            var response = await _client.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.LogInformation(content);
                weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }

        return weatherData;
    }
}
