using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.GlobalException
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var (statusCode, message) = ex switch
                {
                    ArgumentException or BadHttpRequestException =>
                        (StatusCodes.Status400BadRequest, ex.Message),

                    UnauthorizedAccessException =>
                        (StatusCodes.Status401Unauthorized,
                         "Unauthorized access."),

                    KeyNotFoundException =>
                        (StatusCodes.Status404NotFound,
                         "The requested resource was not found."),

                    DbUpdateException =>
                        (StatusCodes.Status409Conflict,
                         "The operation could not be completed because of a related data constraint."),

                    NotImplementedException =>
                        (StatusCodes.Status501NotImplemented,
                         "Action not implemented."),

                    _ =>
                        (StatusCodes.Status500InternalServerError,
                         "An internal server error occurred.")
                };

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsJsonAsync(new
                {
                    StatusCode = statusCode,
                    Message = message
                });
            }
        }
    }
}