using PulseAndPower.BusinessLogic.Exceptions;
using PulseAndPower.BusinessLogic.Infrastructure;
using PulseAndPower.BusinessLogic.Models.Common;
using PulseAndPower.BusinessLogic.Models.Request;
using PulseAndPower.BusinessLogic.Models.Results;
using PulseAndPower.BusinessLogic.Services.Interfaces;
using Vostok.Logging.Abstractions;

namespace PulseAndPower.BusinessLogic.Services;

public class UserService: IUserService
{
    private readonly ILog log;
    private readonly IUsersDatabaseDriver driver;

    public UserService(ILog log, IUsersDatabaseDriver driver)
    {
        this.log = log;
        this.driver = driver;
    }

    public async Task<GetUserResult> CreateUser(UserRequest request)
    {
        var user = await GetUserEntity();
        if (user.Status != UserStatus.PhoneVerified)
            throw new BadRequestException($"user with id {user.Id} is already created or has not verified phone");
        
        user.FirstName = request.FirstName ?? throw new BadRequestException("Firstname can not be null");
        user.LastName = request.LastName ?? throw new BadRequestException("Lastname can not be null");
        user.Patronymic = request.Patronymic;
        user.FavouritePlaces = request.FavouritePlaces ?? new List<Guid>();
        user.Status = UserStatus.Activated;
        await driver.UpdateUser(user);
        
        return await GetUserResult(user);
    }

    public async Task<GetUserResult> GetUserInfo() => await GetUserResult(await GetUserEntity());
    
    public async Task<GetPlacesResult> AddFavouritePlace(PlacesRequest request)
    {
        foreach (var placeId in request.PlaceIds)
        {
            var address = await driver.GetPlaceInfoOrDefault(placeId);
            if (address == null)
                throw new BadRequestException($"Address with id {placeId} not found");
        }

        await driver.UpdateUser(GlobalContext.UserId, user => user.FavouritePlaces.AddRange(request.PlaceIds));
        return await GetFavouritePlaces();
    }

    public async Task<GetPlacesResult> GetFavouritePlaces() => new()
    {
        Addresses = await GetAddresses((await driver.GetUserEntity(GlobalContext.UserId))?.FavouritePlaces)
    };

    public async Task<GetPlacesResult> DeleteFavouritePlace(Guid placeId)
    {
        await driver.UpdateUser(GlobalContext.UserId, user => user.FavouritePlaces.Remove(placeId));
        return await GetFavouritePlaces();
    }

    private async Task<UserEntity> GetUserEntity()
    {
        var userId = GlobalContext.UserId;
        var user = await driver.GetUserEntity(userId);
        if (user == null)
            throw new BadRequestException($"User with id {userId} not found");
        return user;
    }

    private async Task<GetUserResult> GetUserResult(UserEntity user) => new()
    {
        Id = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Patronymic = user.Patronymic,
        FavouritePlaces = await GetAddresses(user.FavouritePlaces)
    };

    private async Task<Dictionary<string, Address>> GetAddresses(IEnumerable<Guid>? ids)
    {
        var result = new Dictionary<string, Address>();
        foreach (var id in ids ?? Array.Empty<Guid>())
        {
            var address = await driver.GetPlaceInfoOrDefault(id);
            result[address!.City] = address;
        }

        return result;
    }
}