using Application.Contracts.Service;
using Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WeatherForecastAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [Route("GetByCordinates")]
        [HttpGet]
        public async Task<IActionResult> Get(double lattitude, double longitude)
        {
            var weatherForecastData = await _weatherForecastService.GetWeatherForecastByCordinatesAsync(lattitude, longitude);
            return Ok(weatherForecastData);
        }

        [Route("GetByCustomRequest")]
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] WeatherForecastRequest weatherForecastRequest)
        {
            var weatherForecastData = await _weatherForecastService.GetWeatherForecastAsync(weatherForecastRequest);
            return Ok(weatherForecastData);
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _weatherForecastService.DeleteWeatherForecastAsync(id);
            return Ok(success);
        }


        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var weatherForecastData = await _weatherForecastService.GetAllWeatherForecastAsync();
            return Ok(weatherForecastData);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(double lattitude, double longitude)
        {
            var weatherForecastData = await _weatherForecastService.RefreshWeatherForecastAsync(lattitude, longitude);
            return Ok(weatherForecastData);
        }
    }
}