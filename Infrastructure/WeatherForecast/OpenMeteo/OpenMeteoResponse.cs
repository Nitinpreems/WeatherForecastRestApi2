using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.WeatherForecast.OpenMeteo
{
    
    public class OpenMeteoResponse
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public double elevation { get; set; }
        public HourlyUnits hourly_units { get; set; }
        public Hourly hourly { get; set; }
        public DailyUnits daily_units { get; set; }
        public Daily daily { get; set; }
    }
    public class Daily
    {
        public List<string> time { get; set; }
        public List<int> weathercode { get; set; }
        public List<double> temperature_2m_max { get; set; }
        public List<double> temperature_2m_min { get; set; }
        public List<double> precipitation_sum { get; set; }
        public List<double> rain_sum { get; set; }
        public List<double> showers_sum { get; set; }
    }

    public class DailyUnits
    {
        public string time { get; set; }
        public string weathercode { get; set; }
        public string temperature_2m_max { get; set; }
        public string temperature_2m_min { get; set; }
        public string precipitation_sum { get; set; }
        public string rain_sum { get; set; }
        public string showers_sum { get; set; }
    }

    public class Hourly
    {
        public List<string> time { get; set; }
        public List<double> temperature_2m { get; set; }
        public List<int> relativehumidity_2m { get; set; }
        public List<double> dewpoint_2m { get; set; }
        public List<int> weathercode { get; set; }
        public List<double> pressure_msl { get; set; }
        public List<double> surface_pressure { get; set; }
    }

    public class HourlyUnits
    {
        public string time { get; set; }
        public string temperature_2m { get; set; }
        public string relativehumidity_2m { get; set; }
        public string dewpoint_2m { get; set; }
        public string weathercode { get; set; }
        public string pressure_msl { get; set; }
        public string surface_pressure { get; set; }
    }

    


}
