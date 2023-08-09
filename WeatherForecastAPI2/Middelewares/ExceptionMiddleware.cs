
using Application.Exceptions;
using Newtonsoft.Json;
using System.Net;


namespace WeatherForecastAPI2.Middelewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException e)
            {
                string exception = JsonConvert.SerializeObject(e.ValidationErrors);
                _logger.LogError($"Validation Exception: {exception}");
                await WriteErrorResponse(context, HttpStatusCode.BadRequest, exception);
            }
            catch (BadRequestException e)
            {
                string exception = JsonConvert.SerializeObject(e.ErrorMessage);
                _logger.LogError($"Bad Request Exception: {exception}");
                await WriteErrorResponse(context, HttpStatusCode.BadRequest, exception);
            }
            catch (HttpRequestException e)
            {
                _logger.LogError($"Http Request Exception : {JsonConvert.SerializeObject(e)}");
                await WriteErrorResponse(context, e.StatusCode ?? HttpStatusCode.InternalServerError, e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"Unhandled Excep: {JsonConvert.SerializeObject(e)}");
                await WriteErrorResponse(context, HttpStatusCode.InternalServerError, "Internal Server Error Occured!");
            }
        }
        private async Task WriteErrorResponse(HttpContext context, HttpStatusCode statusCode, string errorMessage)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorMessage));
        }
    }
}
