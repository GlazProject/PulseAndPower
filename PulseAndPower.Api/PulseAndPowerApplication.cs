using PulseAndPower.BusinessLogic.Settings;
using PulseAndPower.DI;
using Vostok.Applications.AspNetCore;
using Vostok.Applications.AspNetCore.Builders;
using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Abstractions.Requirements;

namespace PulseAndPower;

[RequiresSecretConfiguration(typeof(SecretSettings))]
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
            
            setupBuilder.Services.AddSingleton(environment.SecretConfigurationProvider.Get<SecretSettings>());
            setupBuilder.Services.AddSingleton(environment.SecretConfigurationProvider.Get<SecretSettings>().AuthSettings);
            setupBuilder.Services.RegisterMongo();
            setupBuilder.Services.RegisterBusinessLogic();
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
}