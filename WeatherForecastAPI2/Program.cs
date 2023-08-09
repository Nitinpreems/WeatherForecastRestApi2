using Infrastructure.Configuration;
using Application.Configuration;
using Application.Options;
using WeatherForecastAPI2.Middelewares;
using Persistence.Configuration;

namespace WeatherForecastAPI2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddPersistence();
            builder.Services.AddInfrastructure();
            builder.Services.Configure<WeatherForcastSourceApiOptions>(builder.Configuration.GetSection(WeatherForcastSourceApiOptions.WeatherForcastSourceApi));
            builder.Services.AddApplicationCore();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddHttpClient();

            var app = builder.Build();

            //var loggerFactory = app.Services.GetService<ILoggerFactory>();
            //loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            //app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
