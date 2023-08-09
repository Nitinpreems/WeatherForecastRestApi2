

namespace Domain
{
    public class WeatherForecastData
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? GenerationTime { get; set; }
        public int? UtcOffsetSeconds { get; set; }
        public string? Timezone { get; set; }
        public string? TimezoneAbbreviation { get; set; }
        public double? Elevation { get; set; }
        public virtual ICollection<TimeSeriesDataSet> TimelyData { get; } = new List<TimeSeriesDataSet>();
    }

    public class TimeSeriesDataSet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Time { get; set; }
        public string? Value { get; set; }
        public DataSetFrequencyEnum DataSetFrequency { get; set; }
        public int WeatherForecastDataModelId { get; set; }
        public WeatherForecastData WeatherForecast { get; set; } = null!;
    }

    public enum DataSetFrequencyEnum
    {
        Daily,
        Hourly
    }
}
