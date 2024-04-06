using MongoDB.Driver;
using PulseAndPower.BusinessLogic.Exceptions;
using PulseAndPower.BusinessLogic.Models.Common;
using PulseAndPower.BusinessLogic.Services.Interfaces;
using PulseAndPower.BusinessLogic.Settings;
using Vostok.Logging.Abstractions;

namespace PulseAndPower.BusinessLogic.Services;

public class MongoDriver: IAuthDatabaseDriver
{
    private readonly ILog log;
    private readonly IMongoCollection<User> users;
    private readonly IMongoCollection<SidEntity> sessions;
    private readonly IMongoCollection<VerificationCodeEntity> verificationCodes;

    public MongoDriver(IMongoClient client, ILog log, MongoSettings settings)
    {
        this.log = log.ForContext<MongoDriver>();
        sessions = client.GetDatabase(settings.DatabaseName).GetCollection<SidEntity>(settings.SidCollectionName);
        
        users = client.GetDatabase(settings.DatabaseName).GetCollection<User>(settings.UsersCollectionName);
        users.Indexes.CreateOne(new CreateIndexModel<User>(Builders<User>.IndexKeys.Ascending(x => x.Phone), new CreateIndexOptions { Unique = true }));
        
        verificationCodes = client.GetDatabase(settings.DatabaseName).GetCollection<VerificationCodeEntity>(settings.VerificationCodesCollectionName);
    }

    public async Task<User> GetOrCreateUser(string phone)
    {
        log.Info("Try get user by phone");
        var user = await (await users.FindAsync(u => u.Phone == phone)).FirstOrDefaultAsync();
        if (user != null)
            return user;

        log.Info($"User with phone {phone} not found. Create new entity");
        user = new User
        {
            Id = Guid.NewGuid(),
            Phone = phone
        };
        await users.InsertOneAsync(user);
        return user;
    }

    public async Task UpdateUser(Guid userId, Action<User> updatingRules)
    {
        log.Info($"Modify user with id {userId}");
        var user = await (await users.FindAsync(u => u.Id == userId)).FirstOrDefaultAsync();
        if (user == null)
            throw new BadRequestException("User was not found");

        updatingRules(user);
        await users.ReplaceOneAsync(u => u.Id == user.Id, user);
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
}