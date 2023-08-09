
using Domain;

namespace Application.Contracts.ViewModel
{
    public class WeatherForecastVM
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; }
        public double GenerationTime { get; set; }
        public int UtcOffsetSeconds { get; set; }
        public string? Timezone { get; set; }
        public string? TimezoneAbbreviation { get; set; }
        public List<TimeSeriesDataSetVM> TimelyData { get; set; } = new List<TimeSeriesDataSetVM>();
    }

    public class TimeSeriesDataSetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Value { get; set; }
        public DataSetFrequencyEnum TimeSeriesType { get; set; }
    }
}
