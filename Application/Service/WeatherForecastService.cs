using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Contracts.Service;
using Application.Contracts.ViewModel;
using Application.Requests;
using Application.Exceptions;
using AutoMapper;
using FluentValidation;
using System.Net;
using Domain;

namespace Application.Service
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastProvider _weatherForecastProvider;
        private readonly IValidator<WeatherForecastRequest> _requestValidator;
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly IMapper _mapper;
        public WeatherForecastService(IWeatherForecastProvider weatherForecastProvider, IWeatherForecastRepository weatherForecastRepository, IValidator<WeatherForecastRequest> requestValidator, IMapper mapper)
        {
            _weatherForecastProvider = weatherForecastProvider;
            _requestValidator = requestValidator;
            _weatherForecastRepository = weatherForecastRepository;
            _mapper = mapper;
        }
        public async Task<WeatherForecastVM> GetWeatherForecastByCordinatesAsync(double lattitude, double longitude)
        {
            var weatherForecastRequest = new WeatherForecastRequest();
            weatherForecastRequest.Latitude = lattitude;
            weatherForecastRequest.Longitude = longitude;
            var validationResult = await _requestValidator.ValidateAsync(weatherForecastRequest);
            if (validationResult.IsValid == false)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var resultData = await _weatherForecastRepository.GetWeatherForecastByCordinatesAsync(lattitude, longitude);

            if (resultData != null)
            {
                return _mapper.Map<WeatherForecastVM>(resultData);
            }
            else
            {
                return await GetWeatherForecastAsync(weatherForecastRequest);
            }
        }
        
        public async Task<WeatherForecastVM> GetWeatherForecastAsync(WeatherForecastRequest weatherForecastRequest)
        {
            var validationResult = await _requestValidator.ValidateAsync(weatherForecastRequest);
            if (validationResult.IsValid == false)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var weatherForecastViewModel = await _weatherForecastProvider.GetWeatherForecastAsync(weatherForecastRequest);
            var weatherForecastData = _mapper.Map<WeatherForecastData>(weatherForecastViewModel);

            await _weatherForecastRepository.SaveUpdateWeatherForecastAsync(weatherForecastData);
            return weatherForecastViewModel;
        }

        public async Task<IEnumerable<WeatherForecastVM>> GetAllWeatherForecastAsync()
        {
            var forecastHistoryData = await _weatherForecastRepository.GetAllWeatherForecastAsync();
            List<WeatherForecastVM> weatherForecastHistory = _mapper.Map<List<WeatherForecastVM>>(forecastHistoryData);

            return weatherForecastHistory;
        }
   
        public async Task<WeatherForecastVM> RefreshWeatherForecastAsync(double lattitude, double longitude)
        {
            var weatherForecastRequest = new WeatherForecastRequest();
            weatherForecastRequest.Latitude = lattitude;
            weatherForecastRequest.Longitude = longitude;
            return await GetWeatherForecastAsync(weatherForecastRequest);
        }
        public async Task<bool> DeleteWeatherForecastAsync(int id)
        {
            await _weatherForecastRepository.DeleteWeatherForecastAsync(id);
            return true;
        }

    }
}
