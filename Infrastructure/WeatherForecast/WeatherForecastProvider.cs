using Application.Contracts.Infrastructure;
using Application.Contracts.ViewModel;
using Application.Requests;
using Infrastructure.WeatherForecast.OpenMeteo;


namespace Infrastructure.WeatherForecast
{
    public class WeatherForecastProvider : IWeatherForecastProvider
    {
        private readonly IOpenMeteoClient _openMeteoClient;

        public WeatherForecastProvider(IOpenMeteoClient openMeteoClient)
        {
            _openMeteoClient = openMeteoClient;
        }
        public async Task<WeatherForecastVM> GetWeatherForecastAsync(WeatherForecastRequest weatherForecastRequest)
        {
            var openMeteoResponse = await _openMeteoClient.GetForecastAsync(weatherForecastRequest);

            return openMeteoResponse.ToWeatherForecastResponse();
        }
    }
}
