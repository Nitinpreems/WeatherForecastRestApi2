using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class WeatherForecastRepository : BaseRepository<WeatherForecastData>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<WeatherForecastData> GetWeatherForecastByCordinatesAsync(double lattitude, double longitude)
        {
            var currentForecastData = await FindByCondition(wf => wf.Latitude == lattitude && wf.Longitude == longitude);
            return currentForecastData;
        }

        public async Task<IEnumerable<WeatherForecastData>> GetAllWeatherForecastAsync()
        {
            return await GetAll();
        }

        public async Task<WeatherForecastData> SaveUpdateWeatherForecastAsync(WeatherForecastData weatherForecast)
        {
            var currentForecastData = await FindByCondition(wf => wf.Latitude == weatherForecast.Latitude && wf.Longitude == weatherForecast.Longitude,
                                                                     true, new List<string> { "TimelyData" });

            if (currentForecastData != null && weatherForecast != null)
            {
                currentForecastData.TimezoneAbbreviation = weatherForecast?.TimezoneAbbreviation;
                currentForecastData.Timezone = weatherForecast?.Timezone;
                currentForecastData.GenerationTime = weatherForecast?.GenerationTime ?? 0;
                currentForecastData.Elevation = weatherForecast?.Elevation ?? 0;
                currentForecastData.UtcOffsetSeconds = weatherForecast?.UtcOffsetSeconds ?? 0;

                currentForecastData.TimelyData.Clear();
                foreach (var item in weatherForecast.TimelyData)
                {
                    currentForecastData.TimelyData.Add(item);
                }

                return await Update(currentForecastData);
            }

            return await Add(weatherForecast);
        }

        public async Task<bool> DeleteWeatherForecastAsync(int id)
        {
            await Delete(id);
            return true;
        }
    }
}
