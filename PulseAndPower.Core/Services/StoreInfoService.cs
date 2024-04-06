using PulseAndPower.BusinessLogic.Models.Results;
using PulseAndPower.BusinessLogic.Services.Interfaces;
using Vostok.Logging.Abstractions;

namespace PulseAndPower.BusinessLogic.Services;

public class StoreInfoService: IStoreInfoService
{
    private readonly ILog log;
    private readonly IStoreInfoDatabaseDriver driver;

    public StoreInfoService(IStoreInfoDatabaseDriver driver, ILog log)
    {
        this.driver = driver;
        this.log = log;
    }

    public async Task<GetPlacesResult> GetAllPlaces() =>
        new()
        {
            Addresses = (await driver.GetAllPlaces()).ToDictionary(a => a.City, a => a)
        };
}