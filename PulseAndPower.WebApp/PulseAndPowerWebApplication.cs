using System.Net;
using System.Security.Authentication;
using PulseAndPower.BusinessLogic.Exceptions;
using PulseAndPower.BusinessLogic.Settings;
using PulseAndPower.WebApp.DI;
using Vostok.Applications.AspNetCore;
using Vostok.Applications.AspNetCore.Builders;
using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Abstractions.Requirements;

namespace PulseAndPower.WebApp;

[RequiresConfiguration(typeof(ApplicationSettings))]
public class PulseAndPowerWebApplication: VostokAspNetCoreWebApplication
{
    public override Task SetupAsync(IVostokAspNetCoreWebApplicationBuilder builder, IVostokHostingEnvironment environment)
    {
        builder.SetupWebApplication(setupBuilder =>
        {
            setupBuilder.Services.AddControllers();
            setupBuilder.Services.AddEndpointsApiExplorer();
            setupBuilder.Services.AddVostokTracing(setup => setup.ResponseTraceIdHeader = "TraceId");
            setupBuilder.Services.AddVostokRequestInfo(setup => setup.DefaultTimeoutProvider = _ => TimeSpan.FromSeconds(30));
            setupBuilder.Services.AddVostokRequestLogging(setup =>
            {
                setup.LogResponseCompletion = true;
                setup.LogQueryString = true;
            });
            
            setupBuilder.Services.AddSingleton(environment.ConfigurationProvider.Get<ApplicationSettings>());
            setupBuilder.Services.RegisterBusinessLogic();
        });

        builder.CustomizeWebApplication(app =>
        {
            app.UseVostokTracing();
            app.UseAuthorization();
            app.MapControllers();
            app.UseRouting();
            app.UseVostokRequestInfo();
            app.UseVostokUnhandledExceptions();
            app.UseResponseExceptionHandler(setup =>
                {
                    setup.Map<AuthenticationException>(HttpStatusCode.Unauthorized);
                    setup.Map<BadRequestException>(HttpStatusCode.BadRequest);
                    setup.Map<ForbiddenException>(HttpStatusCode.Forbidden);
                }
            );
        });

        return Task.CompletedTask;
    }
}