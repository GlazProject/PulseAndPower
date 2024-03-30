using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PulseAndPower.Models.Generated;

/// <summary>
/// Gets or Sets TimeOfDay
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TimeOfDay
{
    /// <summary>
    /// Enum Enum for Утренние
    /// </summary>
    [EnumMember(Value = "Утренние")]
    Morning = 0,
    /// <summary>
    /// Enum Enum for Весь день
    /// </summary>
    [EnumMember(Value = "Весь день")]
    AllDay = 1,
    /// <summary>
    /// Enum Enum for Вечерние
    /// </summary>
    [EnumMember(Value = "Вечерние")]
    Evening = 2
    
}