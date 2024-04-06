using PulseAndPower.BusinessLogic.Models.Common;

namespace PulseAndPower.BusinessLogic.Services.Interfaces;

public interface IUsersDatabaseDriver
{
    Task<UserEntity?> GetUserEntity(Guid userId);
    Task<UserEntity> UpdateUser(UserEntity user);
    Task UpdateUser(Guid userId, Action<UserEntity> updatingRules);

    Task<Address?> GetPlaceInfoOrDefault(Guid placeId);
}