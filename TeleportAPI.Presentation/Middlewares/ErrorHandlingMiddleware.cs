using System.Net;
using System.Text.Json;
using TeleportAPI.Application.Exceptions;
using TeleportAPI.Application.Utilities;
using TeleportAPI.Application.Wrappers;

namespace TeleportAPI.Presentation.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
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
            catch (Exception e)
            {
                await HandleErrorAsync(context, e);
            }
        }

        private async Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            Response response = new Response { IsSucceeded = false };
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case ValidationException e:
                    response.Errors = e.Errors;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    break;
                default:
                    response.Errors.Add(ErrorMessages.ErrorOccuredMessage());
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    _logger.LogError(exception, $"{exception.Message} {exception.InnerException.Message}");
                    break;
            }

        }
    }

}
