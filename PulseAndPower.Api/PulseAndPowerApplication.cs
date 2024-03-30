using Vostok.Applications.AspNetCore;
using Vostok.Applications.AspNetCore.Builders;
using Vostok.Hosting.Abstractions;

namespace PulseAndPower;

public class PulseAndPowerApplication: VostokAspNetCoreWebApplication
{
    public override Task SetupAsync(IVostokAspNetCoreWebApplicationBuilder builder, IVostokHostingEnvironment environment)
    {
        builder.SetupWebApplication(setupBuilder =>
        {
            setupBuilder.Services.AddControllers();
            setupBuilder.Services.AddEndpointsApiExplorer();
            setupBuilder.Services.AddSwaggerGen();
            setupBuilder.Services.AddVostokTracing(setup => setup.ResponseTraceIdHeader = "TraceId");
            setupBuilder.Services.AddVostokRequestInfo(setup => setup.DefaultTimeoutProvider = _ => TimeSpan.FromSeconds(30));
            setupBuilder.Services.AddVostokRequestLogging(setup =>
            {
                setup.LogResponseCompletion = true;
                setup.LogQueryString = true;
            });
        });

        builder.CustomizeWebApplication(app =>
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseVostokTracing();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseRouting();
            app.UseVostokRequestInfo();
            app.UseVostokUnhandledExceptions();
        });

        return Task.CompletedTask;
    }

    public override Task WarmupAsync(IVostokHostingEnvironment environment, WebApplication webApplication)
    {
        return Task.CompletedTask;
    }
}