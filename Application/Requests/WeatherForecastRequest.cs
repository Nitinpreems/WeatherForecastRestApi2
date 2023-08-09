using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class WeatherForecastRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public TimeZoneEnum Timezone { get; set; }
        public string Timezone { get; set; }
        public List<string>? HourlyDataSets { get; set; }  
        public List<string>? DailyDataSets { get; set; }

    }
}
