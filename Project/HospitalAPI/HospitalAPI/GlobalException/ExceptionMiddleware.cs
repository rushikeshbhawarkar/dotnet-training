using System.Net;
using System.Text.Json;

namespace HospitalAPI.GlobalException
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            context.Response.ContentType = "application/json";

            int statusCode = exception switch
            {
                KeyNotFoundException => StatusCodes.Status404NotFound,

                ArgumentException => StatusCodes.Status400BadRequest,

                InvalidOperationException => StatusCodes.Status400BadRequest,

                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;

            var response = new
            {
                statusCode = statusCode,
                message = GetErrorMessage(statusCode, exception)
            };

            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }

        private static string GetErrorMessage(
            int statusCode,
            Exception exception)
        {
            return statusCode switch
            {
                StatusCodes.Status404NotFound =>
                    exception.Message,

                StatusCodes.Status400BadRequest =>
                    exception.Message,

                StatusCodes.Status401Unauthorized =>
                    "You are not authorized to access this resource.",

                _ =>
                    "An unexpected error occurred. Please try again later."
            };
        }
    }
}