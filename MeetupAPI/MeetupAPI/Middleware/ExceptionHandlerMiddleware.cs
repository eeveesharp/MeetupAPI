using Newtonsoft.Json;
using System.Net;

namespace MeetupAPI.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, 
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate.Invoke(context);
            }
            catch (Exception exception)
            {
                context.Response.ContentType = "application/json";

                var statusCode = HttpStatusCode.InternalServerError;

                _logger.LogError(exception.Message);
                _logger.LogError(exception.StackTrace);

                var result = JsonConvert.SerializeObject(new
                {
                    StatusCode = statusCode,
                    ErrorMessage = exception.Message
                });

                context.Response.StatusCode = (int)statusCode;

                await context.Response.WriteAsync(result);
            }
        }
    }
}
