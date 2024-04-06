using PulseAndPower.BusinessLogic.Models.Common;

namespace PulseAndPower.BusinessLogic.Models.Results;

public class GetPlacesResult
{
    public Dictionary<string, Address> Addresses { get; set; }
}