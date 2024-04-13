using Microsoft.Extensions.Options;
using PulseAndPower.WebApp.Middlewares;
using ExceptionHandlerOptions = PulseAndPower.WebApp.Middlewares.ExceptionHandlerOptions;

namespace PulseAndPower.WebApp;

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