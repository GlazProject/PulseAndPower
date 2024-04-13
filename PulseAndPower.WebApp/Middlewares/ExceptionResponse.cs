namespace PulseAndPower.WebApp.Middlewares;

internal class ExceptionResponse
{
    public int StatusCode { get; set; }

    public string Message { get; set; }

    public object Response { get; set; }
}