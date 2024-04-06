using PulseAndPower.BusinessLogic.Models.Common;

namespace PulseAndPower.BusinessLogic.Models.Results;

public class GetOrdersResult
{
    public List<Order> Orders { get; set; }
}