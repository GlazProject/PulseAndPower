using PulseAndPower.Auth.Services.Interfaces;
using PulseAndPower.BusinessLogic.Infrastructure.Auth;
using PulseAndPower.BusinessLogic.Services;
using PulseAndPower.BusinessLogic.Settings;

namespace PulseAndPower.DI;

public static class ServicesRegistry
{
    public static IServiceCollection RegisterBusinessLogic(this IServiceCollection services) =>
        services
            .AddSingleton(sp => sp.GetService<SecretSettings>()!.AuthSettings)
            .AddSingleton<IAuthDatabase, AuthDatabase>()
            .AddSingleton<IAuthSidService, AuthSidService>();
}