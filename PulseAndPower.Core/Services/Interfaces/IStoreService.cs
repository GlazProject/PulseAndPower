using PulseAndPower.BusinessLogic.Models.Common;
using PulseAndPower.BusinessLogic.Models.Request;
using PulseAndPower.BusinessLogic.Models.Results;

namespace PulseAndPower.BusinessLogic.Services.Interfaces;

public interface IStoreService
{
    Task<Order> CreateOrder(OrderRequest request);
    Task<GetOrdersResult> GetOrders();
}