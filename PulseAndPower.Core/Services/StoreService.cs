using PulseAndPower.BusinessLogic.Exceptions;
using PulseAndPower.BusinessLogic.Infrastructure;
using PulseAndPower.BusinessLogic.Models.Common;
using PulseAndPower.BusinessLogic.Models.Request;
using PulseAndPower.BusinessLogic.Models.Results;
using PulseAndPower.BusinessLogic.Services.Interfaces;

namespace PulseAndPower.BusinessLogic.Services;

public class StoreService : IStoreService
{
    private readonly IStoreDatabaseDriver driver;

    public StoreService(IStoreDatabaseDriver driver)
    {
        this.driver = driver;
    }

    public async Task<Order> CreateOrder(OrderRequest request)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = GlobalContext.UserId,
            Date = DateTime.UtcNow,
            Subscription = new Subscription
            {
                Duration = request.Duration,
                Options = request.TrainingType,
                TimeOfDay = request.TimeOfDay
            }
        };
        await driver.PutOrder(order);
        return order;
    }

    public async Task<GetOrdersResult> GetOrders()
    {
        return new GetOrdersResult
        {
            Orders = (await driver.GetOrders(GlobalContext.UserId)).ToList()
        };
    }
}