using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using PulseAndPower.BusinessLogic.Models.Results;
using Vostok.Logging.Abstractions;
using ExceptionHandlerOptions = PulseAndPower.WebApp.Middlewares.ExceptionHandlerOptions;

namespace PulseAndPower.WebApp.Middlewares;

internal class ExceptionHandlerMiddleware
{
    private readonly ILog log;
    private readonly RequestDelegate next;
    private readonly ExceptionHandlerOptions options;
    private readonly Func<object, Task> clearCacheHeadersDelegate;

    public ExceptionHandlerMiddleware(RequestDelegate next, IOptions<ExceptionHandlerOptions> options, ILog log)
    {
        this.log = log;
        this.next = next;
        this.options = options.Value;
        clearCacheHeadersDelegate = ClearCacheHeaders;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            if (context.Response.HasStarted)
            {
                log.Warn("The response has already started, the error handler will not be executed.");
                throw;
            }

            var originalPath = context.Request.Path;

            try
            {
                context.Response.Clear();
                context.Response.OnStarting(clearCacheHeadersDelegate, context.Response);
                context.Response.ContentType = new MediaTypeHeaderValue("application/json").ToString();

                if (options.Responses.TryGetValue(ex.GetType(), out var exceptionResponse))
                {
                    context.Response.StatusCode = exceptionResponse.StatusCode;

                    await WriteResponseAsync(context, CreateErrorResponse(exceptionResponse.StatusCode, exceptionResponse.Message ?? ex.Message));

                    log.Warn(ex, $"An exception has occurred: {ex.Message}");
                }
                else
                {
                    const int statusCode = (int) HttpStatusCode.InternalServerError;
                    context.Response.StatusCode = statusCode;
                    await WriteResponseAsync(context, CreateErrorResponse(statusCode, options.DefaultErrorMessage));

                    log.Error(ex, $"An unhandled exception has occurred : {ex.Message}");
                }

                return;
            }
            catch (Exception ex2)
            {
                log.Error(ex2, "An exception was thrown attempting to execute the error handler.");
            }
            finally
            {
                context.Request.Path = originalPath;
            }
            throw;
        }
    }

    private static async Task WriteResponseAsync(HttpContext context, object response)
    {
        await context.Response.WriteAsync(JsonSerializer.Serialize(response), Encoding.UTF8);
    }

    private static ApiError CreateErrorResponse(int statusCode, string message)
    {
        return new ApiError
        {
            StatusCode = statusCode,
            Message = message
        };
    }

    private static Task ClearCacheHeaders(object state)
    {
        var response = (HttpResponse)state;
        response.Headers[HeaderNames.CacheControl] = "no-cache";
        response.Headers[HeaderNames.Pragma] = "no-cache";
        response.Headers[HeaderNames.Expires] = "-1";
        response.Headers.Remove(HeaderNames.ETag);
        return Task.CompletedTask;
    }
}