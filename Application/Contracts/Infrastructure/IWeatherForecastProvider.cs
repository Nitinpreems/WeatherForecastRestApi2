using Application.Contracts.ViewModel;
using Application.Requests;


namespace Application.Contracts.Infrastructure
{
    public interface IWeatherForecastProvider
    {
        Task<WeatherForecastVM> GetWeatherForecastAsync(WeatherForecastRequest weatherForecastRequest);
    }
}
