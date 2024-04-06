using System.Text.Json.Serialization;

namespace PulseAndPower.BusinessLogic.Models.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TimeOfDay
{
    Morning,
    AllDay,
    Evening
}