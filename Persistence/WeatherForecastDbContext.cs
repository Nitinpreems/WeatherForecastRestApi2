using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class WeatherForecastDbContext : DbContext
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : base(options) { }
        public WeatherForecastDbContext() { }
        public DbSet<WeatherForecastData> WeatherForecastData { get; set; }
        public DbSet<TimeSeriesDataSet> TimeSeriesDataSet { get; set; }
    }
}
