using System.Text.Json.Serialization;

namespace PulseAndPower.BusinessLogic.Models.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserStatus
{
    CodeSent,
    PhoneVerified,
    Activated
}