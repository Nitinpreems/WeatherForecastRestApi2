using Application.Requests;
using Microsoft.Extensions.Options;
using System;
using Application.Contracts.Infrastructure;
using System.Text;
using System.Threading.Tasks;
using Application.Options;

namespace Infrastructure.WeatherForecast.OpenMeteo
{
    public class OpenMeteoClient : IOpenMeteoClient
    {
        private readonly IHttpClientsFactory _httpClient;
        private readonly IOptions<WeatherForcastSourceApiOptions> _weatherSpurceApi;

        public OpenMeteoClient(IHttpClientsFactory httpClient, IOptions<WeatherForcastSourceApiOptions> weatherSpurceApi)
        {
            _httpClient = httpClient;
            _weatherSpurceApi = weatherSpurceApi;
        }
        public async Task<OpenMeteoResponse> GetForecastAsync(WeatherForecastRequest weatherForecastRequest)
        {
            var url = GetUrl(weatherForecastRequest);

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            return await _httpClient.SendAsync<OpenMeteoResponse>(httpRequestMessage, CancellationToken.None);
        }

        public string GetUrl(WeatherForecastRequest weatherForecastRequest)
        {
            
            StringBuilder serviceUrl = new StringBuilder($"{_weatherSpurceApi.Value.BaseUrl}/v1/forecast?latitude={weatherForecastRequest.Latitude}&longitude={weatherForecastRequest.Longitude}");

            if (weatherForecastRequest.HourlyDataSets == null && weatherForecastRequest.DailyDataSets == null)
            {
                weatherForecastRequest.HourlyDataSets = new List<string>();
                weatherForecastRequest.HourlyDataSets.Add("temperature_2m");
            }
            
            var hourlyVariable = string.Join(',', weatherForecastRequest.HourlyDataSets);
            var dailyVariables = string.Join(',', weatherForecastRequest.DailyDataSets);

            if (weatherForecastRequest.Timezone != null)
            {
                serviceUrl.Append($"&timezone={weatherForecastRequest.Timezone}");
            }

            if (hourlyVariable != string.Empty)
            {
                serviceUrl.Append($"&hourly={hourlyVariable}");
            }

            if (dailyVariables != string.Empty)
            {
                serviceUrl.Append($"&daily={dailyVariables}");
            }
            

            return serviceUrl.ToString();
        }
    }
}
