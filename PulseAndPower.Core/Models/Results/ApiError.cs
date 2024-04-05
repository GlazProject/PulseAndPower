using System.ComponentModel;

namespace PulseAndPower.BusinessLogic.Models.Results;

public class ApiError
{
    [DefaultValue(400)]
    public int StatusCode { get; set; }

    public string? Message { get; set; }
}