using MongoDB.Driver;
using PulseAndPower.BusinessLogic.Services;
using PulseAndPower.BusinessLogic.Services.Interfaces;
using PulseAndPower.BusinessLogic.Settings;

namespace PulseAndPower.DI;

public static class ServicesRegistry
{
    public static IServiceCollection RegisterBusinessLogic(this IServiceCollection services) =>
        services
            .AddSingleton(sp => sp.GetService<ApplicationSettings>()!.MongoSettings)
            .AddSingleton<IAuthService, AuthService>()
            .AddSingleton<IAuthDatabaseDriver, MongoDriver>()
            .AddSingleton(CreateClient);

    private static IMongoClient CreateClient(IServiceProvider provider)
    {
        var connectionString = provider.GetService<ApplicationSettings>()!.MongoSettings.MongoConnectionString;
        return new MongoClient(connectionString);
    }
}