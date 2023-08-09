using Application.Contracts.ViewModel;
using Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Service
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecastVM> GetWeatherForecastByCordinatesAsync(double lattitude, double longitude);

        Task<WeatherForecastVM> GetWeatherForecastAsync(WeatherForecastRequest weatherForecastRequest);

        Task<IEnumerable<WeatherForecastVM>> GetAllWeatherForecastAsync();

        //public Task<WeatherForecastVM> GetWeatherForecastByIdAsync(int id);

        //public Task<WeatherForecastVM> AddWeatherForecastAsync(WeatherForecastVM WeatherForecastDto);

        Task<WeatherForecastVM> RefreshWeatherForecastAsync(double lattitude, double longitude);

        Task<bool> DeleteWeatherForecastAsync(int id);

        
    }
}
