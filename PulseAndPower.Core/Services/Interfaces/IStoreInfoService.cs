using PulseAndPower.BusinessLogic.Models.Results;

namespace PulseAndPower.BusinessLogic.Services.Interfaces;

public interface IStoreInfoService
{
    Task<GetPlacesResult> GetAllPlaces();
}