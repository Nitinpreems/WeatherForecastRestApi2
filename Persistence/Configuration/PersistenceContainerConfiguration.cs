using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Persistence.Configuration
{
    public static class PersistenceContainerConfiguration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddDbContext<WeatherForecastDbContext>(options => options.UseInMemoryDatabase("WeatherForecastDatabase"))
                .AddScoped<IAsyncRepository<WeatherForecastData>, BaseRepository<WeatherForecastData>>()
                .AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
        }
    }
}
