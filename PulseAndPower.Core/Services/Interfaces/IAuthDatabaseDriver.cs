using PulseAndPower.BusinessLogic.Models.Common;

namespace PulseAndPower.BusinessLogic.Services.Interfaces;

public interface IAuthDatabaseDriver
{
    Task<UserEntity> GetOrCreateUser(string phone);
    Task UpdateUser(Guid userId, Action<UserEntity> updatingRules);
    
    Task<SidEntity> CreateSession(Guid userId);
    Task<SidEntity?> GetSessionOrDefault(Guid sessionId);
    Task DeleteSession(Guid sessionId);

    Task CreateOrUpdateVerificationCode(Guid userId, string verificationCode);
    Task<string?> GetVerificationCodeOrDefault(Guid userId);
    Task DeleteVerificationCode(Guid userId);
}