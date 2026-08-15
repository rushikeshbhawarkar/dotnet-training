namespace aug_10.GlobalException
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;//internal
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new { Message = ex.Message });
            }
        }
    }
}
