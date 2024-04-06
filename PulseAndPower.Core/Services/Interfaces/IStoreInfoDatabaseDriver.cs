using PulseAndPower.BusinessLogic.Models.Common;

namespace PulseAndPower.BusinessLogic.Services.Interfaces;

public interface IStoreInfoDatabaseDriver
{
    Task<IEnumerable<Address>> GetAllPlaces();
}