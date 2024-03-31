using MongoDB.Driver;
using PulseAndPower.BusinessLogic.Settings;

namespace PulseAndPower.DI;

public static class DbRegistry
{
    public static IServiceCollection RegisterMongo(this IServiceCollection services) => 
        services.AddSingleton(CreateClient);

    private static IMongoClient CreateClient(IServiceProvider provider)
    {
        var connectionString = provider.GetService<SecretSettings>()!.MongoConnectionString;
        return new MongoClient(connectionString);
    }
}