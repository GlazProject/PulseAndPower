using MongoDB.Driver;
using PulseAndPower.BusinessLogic.Exceptions;
using PulseAndPower.BusinessLogic.Models.Common;
using PulseAndPower.BusinessLogic.Services.Interfaces;
using PulseAndPower.BusinessLogic.Settings;
using Vostok.Logging.Abstractions;

namespace PulseAndPower.BusinessLogic.Services;

public class MongoDriver: IAuthDatabaseDriver, IUsersDatabaseDriver, IStoreInfoDatabaseDriver, IStoreDatabaseDriver
{
    private readonly ILog log;
    private readonly IMongoCollection<UserEntity> users;
    private readonly IMongoCollection<SidEntity> sessions;
    private readonly IMongoCollection<VerificationCodeEntity> verificationCodes;
    private readonly IMongoCollection<Address> addresses;
    private readonly IMongoCollection<Order> orders;

    public MongoDriver(IMongoClient client, ILog log, MongoSettings settings)
    {
        this.log = log.ForContext<MongoDriver>();
        sessions = client.GetDatabase(settings.DatabaseName).GetCollection<SidEntity>(settings.SidCollectionName);
        
        users = client.GetDatabase(settings.DatabaseName).GetCollection<UserEntity>(settings.UsersCollectionName);
        users.Indexes.CreateOne(new CreateIndexModel<UserEntity>(Builders<UserEntity>.IndexKeys.Ascending(x => x.Phone), new CreateIndexOptions { Unique = true }));
        
        verificationCodes = client.GetDatabase(settings.DatabaseName).GetCollection<VerificationCodeEntity>(settings.VerificationCodesCollectionName);
        addresses = client.GetDatabase(settings.DatabaseName).GetCollection<Address>(settings.AddressesCollectionName);
        orders = client.GetDatabase(settings.DatabaseName).GetCollection<Order>(settings.OrdersCollectionName);
    }

    public async Task<UserEntity> GetOrCreateUser(string phone)
    {
        log.Info("Try get user by phone");
        var user = await (await users.FindAsync(u => u.Phone == phone)).FirstOrDefaultAsync();
        if (user != null)
            return user;

        log.Info($"User with phone {phone} not found. Create new entity");
        user = new UserEntity
        {
            Id = Guid.NewGuid(),
            Phone = phone
        };
        await users.InsertOneAsync(user);
        return user;
    }

    public async Task<UserEntity?> GetUserEntity(Guid userId)
    {
        log.Info($"Try get user by id {userId}");
        return await (await users.FindAsync(u => u.Id == userId)).FirstOrDefaultAsync();
    }

    public async Task<UserEntity> UpdateUser(UserEntity user)
    {
        log.Info($"Modify user with id {user.Id}");
        var userEntity = await (await users.FindAsync(u => u.Id == user.Id)).FirstOrDefaultAsync();
        if (user == null)
            throw new BadRequestException("User was not found");
        
        await users.ReplaceOneAsync(u => u.Id == user.Id, user);
        return user;
    }

    public async Task UpdateUser(Guid userId, Action<UserEntity> updatingRules)
    {
        log.Info($"Modify user with id {userId}");
        var user = await (await users.FindAsync(u => u.Id == userId)).FirstOrDefaultAsync();
        if (user == null)
            throw new BadRequestException("User was not found");

        updatingRules(user);
        user.Id = userId;
        await users.ReplaceOneAsync(u => u.Id == userId, user);
    }

    public async Task<Address?> GetPlaceInfoOrDefault(Guid placeId)
    {
        log.Info($"Get place by id {placeId}");
        return await (await addresses.FindAsync(u => u.Id == placeId)).FirstOrDefaultAsync();
    }

    public async Task<SidEntity> CreateSession(Guid userId)
    {
        log.Info($"Create session for user {userId}");
        var session = new SidEntity
        {
            Id = Guid.NewGuid(),
            UserId = userId
        };
        await sessions.InsertOneAsync(session);
        return session;
    }

    public async Task<SidEntity?> GetSessionOrDefault(Guid sessionId) =>
        await (await sessions.FindAsync(s => s.Id == sessionId)).FirstOrDefaultAsync();

    public async Task DeleteSession(Guid sessionId) => 
        await sessions.DeleteOneAsync(s => s.Id == sessionId);

    public async Task CreateOrUpdateVerificationCode(Guid userId, string verificationCode)
    {
        var entity = new VerificationCodeEntity
        {
            Id = userId,
            VerificationCode = verificationCode
        };
        
        var result = await verificationCodes.ReplaceOneAsync(c => c.Id == entity.Id, entity);
        if (!result.IsAcknowledged || result.ModifiedCount <= 0)
            await verificationCodes.InsertOneAsync(entity);
    }

    public async Task<string?> GetVerificationCodeOrDefault(Guid userId)
    {
        var codeEntity = await (await verificationCodes.FindAsync(c => c.Id == userId)).FirstOrDefaultAsync();
        return codeEntity?.VerificationCode;
    }

    public async Task DeleteVerificationCode(Guid userId) => 
        await verificationCodes.DeleteOneAsync(s => s.Id == userId);

    public async Task<IEnumerable<Address>> GetAllPlaces() => (await addresses.FindAsync(_ => true)).ToEnumerable();
    
    public async Task PutOrder(Order order) => await orders.InsertOneAsync(order);

    public async Task<IEnumerable<Order>> GetOrders(Guid userId) => 
        (await orders.FindAsync(o => o.UserId == userId)).ToEnumerable();
}