using Microsoft.Extensions.Options;
using PulseAndPower.Middlewares;
using ExceptionHandlerOptions = PulseAndPower.Middlewares.ExceptionHandlerOptions;

namespace PulseAndPower;

internal static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseResponseExceptionHandler(this IApplicationBuilder app) => app.UseResponseExceptionHandler(_ => { });

    public static IApplicationBuilder UseResponseExceptionHandler(this IApplicationBuilder app, Action<ExceptionHandlerOptions> setupAction)
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        var options = new ExceptionHandlerOptions();

        setupAction(options);

        return app.UseMiddleware<ExceptionHandlerMiddleware>(Options.Create(options));
    }
}