using MongoDB.Driver;
using PulseAndPower.Auth.Services.Interfaces;
using PulseAndPower.BusinessLogic.Exceptions;
using PulseAndPower.BusinessLogic.Infrastructure;
using PulseAndPower.BusinessLogic.Models.DB;
using PulseAndPower.BusinessLogic.Settings;

namespace PulseAndPower.BusinessLogic.Services;

public class AuthSidService: IAuthSidService
{
    private readonly IMongoCollection<SidEntity> sidCollection;

    public AuthSidService(IMongoClient client, AuthSettings settings)
    {
        sidCollection = client.GetDatabase(settings.DatabaseName).GetCollection<SidEntity>(settings.SidCollectionName);
        sidCollection.Indexes.CreateOne(new CreateIndexModel<SidEntity>(Builders<SidEntity>.IndexKeys.Ascending(x => x.Sid), new CreateIndexOptions { Unique = true }));
    }
    
    public async Task ValidateSid(string sid)
    {
        var collection = await sidCollection.FindAsync(s => string.Equals(s.Sid, sid, StringComparison.OrdinalIgnoreCase)).ConfigureAwait(false);
        var entity = await collection.FirstOrDefaultAsync();
        GlobalContext.UserId = entity?.UserId ?? throw ExceptionsHelper.Unauthenticated;
    }
}