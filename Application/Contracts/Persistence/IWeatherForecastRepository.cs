using Domain;

namespace Application.Contracts.Persistence
{
    public interface IWeatherForecastRepository : IAsyncRepository<WeatherForecastData>
    {
        Task<WeatherForecastData> GetWeatherForecastByCordinatesAsync(double lattitude, double longitude);
        Task<WeatherForecastData> SaveUpdateWeatherForecastAsync(WeatherForecastData weatherForecastResponse);
        Task<IEnumerable<WeatherForecastData>> GetAllWeatherForecastAsync();
        Task<bool> DeleteWeatherForecastAsync(int id);
    }
}
