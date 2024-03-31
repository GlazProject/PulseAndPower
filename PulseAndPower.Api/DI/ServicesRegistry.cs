using PulseAndPower.Auth.Services.Interfaces;
using PulseAndPower.BusinessLogic.Infrastructure.Auth;
using PulseAndPower.BusinessLogic.Services;

namespace PulseAndPower.DI;

public static class ServicesRegistry
{
    public static IServiceCollection RegisterBusinessLogic(this IServiceCollection services) =>
        services.AddSingleton<IAuthDatabase, AuthDatabase>()
            .AddSingleton<IAuthSidService, AuthSidService>();
}