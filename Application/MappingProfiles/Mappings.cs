using Application.Contracts.ViewModel;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<WeatherForecastVM, WeatherForecastData>().ReverseMap();
            CreateMap<TimeSeriesDataSetVM, TimeSeriesDataSet>().ReverseMap();
        }
    }
}
