using PulseAndPower.BusinessLogic.Models.Common;

namespace PulseAndPower.BusinessLogic.Services.Interfaces;

public interface IStoreDatabaseDriver
{
    Task PutOrder(Order order);
    Task<IEnumerable<Order>> GetOrders(Guid userId);
}