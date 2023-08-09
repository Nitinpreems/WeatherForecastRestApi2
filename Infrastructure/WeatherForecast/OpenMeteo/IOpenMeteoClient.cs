using Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.WeatherForecast.OpenMeteo
{
    public interface IOpenMeteoClient
    {
        public Task<OpenMeteoResponse> GetForecastAsync(WeatherForecastRequest request);
    }
}
