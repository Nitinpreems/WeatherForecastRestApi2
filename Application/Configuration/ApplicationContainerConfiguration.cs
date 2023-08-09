using Application.Contracts.Service;
using Application.MappingProfiles;
using Application.Options;
using Application.Requests;
using Application.Service;
using Application.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class ApplicationContainerConfiguration
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IValidator<WeatherForecastRequest>, WeatherForecastRequestValidator>()
                .AddScoped<IWeatherForecastService, WeatherForecastService>()
                //.Configure<WeatherForcastSourceApiOptions>(configuration.GetSection(WeatherForcastSourceApiOptions.WeatherForcastSourceApi))
                .AddSingleton(provider => new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new Mapping());

                }).CreateMapper());
        }
    }
}
