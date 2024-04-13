using System.Collections.Concurrent;
using System.Net;

namespace PulseAndPower.WebApp.Middlewares;

internal class ExceptionHandlerOptions
{
    public string DefaultErrorMessage { get; set; } = "An unhandled exception has occurred, please check the log for details.";
    public ConcurrentDictionary<Type, ExceptionResponse> Responses { get; } = new();

    public void Map<TException>(HttpStatusCode statusCode) where TException : Exception
    {
        Map<TException>(statusCode, null);
    }

    public void Map<TException>(HttpStatusCode statusCode, string errorMessage) where TException : Exception
    {
        Map<TException>(statusCode, errorMessage, null);
    }

    public void Map<TException>(HttpStatusCode statusCode, object errorResponse) where TException : Exception
    {
        Map<TException>(statusCode, null, errorResponse);
    }

    private void Map<TException>(HttpStatusCode statusCode, string errorMessage, object errorResponse) where TException : Exception
    {
        var type = typeof(TException);
        var response = new ExceptionResponse
        {
            StatusCode = (int)statusCode,
            Message = errorMessage,
            Response = errorResponse
        };

        if (Responses.TryAdd(type, response))
        {
            return;
        }

        if (Responses.TryRemove(type, out _))
        {
            Responses.TryAdd(type, response);
        }
    }
}