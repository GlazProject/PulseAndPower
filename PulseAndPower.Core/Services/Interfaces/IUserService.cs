using PulseAndPower.BusinessLogic.Models.Request;
using PulseAndPower.BusinessLogic.Models.Results;

namespace PulseAndPower.BusinessLogic.Services.Interfaces;

public interface IUserService
{
    Task<GetUserResult> CreateUser(UserRequest request);
    Task<GetUserResult> GetUserInfo();
    
    Task<GetPlacesResult> AddFavouritePlace(PlacesRequest request);
    Task<GetPlacesResult> GetFavouritePlaces();
    Task<GetPlacesResult> DeleteFavouritePlace(Guid placeId);
}