using MongoDB.Driver;
using PulseAndPower.BusinessLogic.Services;
using PulseAndPower.BusinessLogic.Services.Interfaces;
using PulseAndPower.BusinessLogic.Settings;

namespace PulseAndPower.WebApp.DI;

public static class ServicesRegistry
{
    public static IServiceCollection RegisterBusinessLogic(this IServiceCollection services) =>
        services
            .AddSingleton(sp => sp.GetService<ApplicationSettings>()!.MongoSettings)
            .AddSingleton<IAuthService, AuthService>()
            .AddSingleton<IUserService, UserService>()
            .AddSingleton<IStoreInfoService, StoreInfoService>()
            .AddSingleton<IStoreService, StoreService>()
            .AddSingleton<IAuthDatabaseDriver, MongoDriver>()
            .AddSingleton<IUsersDatabaseDriver, MongoDriver>()
            .AddSingleton<IStoreInfoDatabaseDriver, MongoDriver>()
            .AddSingleton<IStoreDatabaseDriver, MongoDriver>()
            .AddSingleton(CreateClient);

    private static IMongoClient CreateClient(IServiceProvider provider)
    {
        var connectionString = provider.GetService<ApplicationSettings>()!.MongoSettings.MongoConnectionString;
        return new MongoClient(connectionString);
    }
}