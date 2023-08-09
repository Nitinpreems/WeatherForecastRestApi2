using Application.Contracts.Infrastructure;
using Infrastructure.WeatherForecast;
using Infrastructure.WeatherForecast.OpenMeteo;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Infrastructure;

namespace Infrastructure.Configuration
{
    public static class InfrastructureContainerConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<IHttpClientsFactory, HttpClientsFactory>()
                .AddScoped<IWeatherForecastProvider, WeatherForecastProvider>()
                .AddScoped<IOpenMeteoClient, OpenMeteoClient>();
        }
    }
}
