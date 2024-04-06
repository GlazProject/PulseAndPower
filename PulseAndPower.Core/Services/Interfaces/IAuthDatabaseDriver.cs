using PulseAndPower.BusinessLogic.Models.Common;

namespace PulseAndPower.BusinessLogic.Services.Interfaces;

public interface IAuthDatabaseDriver
{
    Task<UserEntity> GetOrCreateUser(string phone);
    Task<UserEntity?> GetUserEntity(Guid userId);
    Task UpdateUser(Guid userId, Action<UserEntity> updatingRules);
    
    Task<SidEntity> CreateSession(Guid userId);
    Task<SidEntity?> GetSessionOrDefault(Guid sessionId);
    Task SetSessionAsVerified(Guid sessionId);
    Task DeleteSession(Guid sessionId);

    Task CreateOrUpdateVerificationCode(Guid sessionId, string verificationCode);
    Task<string?> GetVerificationCodeOrDefault(Guid sessionId);
    Task DeleteVerificationCode(Guid sessionId);
}