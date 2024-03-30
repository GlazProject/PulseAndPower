using System.Runtime.Serialization;
using System.Text;

namespace PulseAndPower.Models.Generated;

/// <summary>
/// 
/// </summary>
[DataContract]
public class Duration : IEquatable<Duration>
{ 
    public enum FriendlyValueEnum
    {
        /// <summary>
        /// Enum _3Enum for 3 месяца
        /// </summary>
        [EnumMember(Value = "3 месяца")]
        _3Enum = 0,
        /// <summary>
        /// Enum _6Enum for 6 месяцев
        /// </summary>
        [EnumMember(Value = "6 месяцев")]
        _6Enum = 1,
        /// <summary>
        /// Enum _1Enum for 1 год
        /// </summary>
        [EnumMember(Value = "1 год")]
        _1Enum = 2        }

    /// <summary>
    /// Gets or Sets FriendlyValue
    /// </summary>

    [DataMember(Name="friendlyValue")]
    public FriendlyValueEnum? FriendlyValue { get; set; }

    /// <summary>
    /// Gets or Sets TimeSpan
    /// </summary>

    [DataMember(Name="timeSpan")]
    public string TimeSpan { get; set; }

    /// <summary>
    /// Returns the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("class Duration {\n");
        sb.Append("  FriendlyValue: ").Append(FriendlyValue).Append("\n");
        sb.Append("  TimeSpan: ").Append(TimeSpan).Append("\n");
        sb.Append("}\n");
        return sb.ToString();
    }

    /// <summary>
    /// Returns true if objects are equal
    /// </summary>
    /// <param name="obj">Object to be compared</param>
    /// <returns>Boolean</returns>
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Duration)obj);
    }

    /// <summary>
    /// Returns true if Duration instances are equal
    /// </summary>
    /// <param name="other">Instance of Duration to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(Duration other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return 
            (
                FriendlyValue == other.FriendlyValue ||
                FriendlyValue != null &&
                FriendlyValue.Equals(other.FriendlyValue)
            ) && 
            (
                TimeSpan == other.TimeSpan ||
                TimeSpan != null &&
                TimeSpan.Equals(other.TimeSpan)
            );
    }

    /// <summary>
    /// Gets the hash code
    /// </summary>
    /// <returns>Hash code</returns>
    public override int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            var hashCode = 41;
            // Suitable nullity checks etc, of course :)
            if (FriendlyValue != null)
                hashCode = hashCode * 59 + FriendlyValue.GetHashCode();
            if (TimeSpan != null)
                hashCode = hashCode * 59 + TimeSpan.GetHashCode();
            return hashCode;
        }
    }

    #region Operators
#pragma warning disable 1591

    public static bool operator ==(Duration left, Duration right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Duration left, Duration right)
    {
        return !Equals(left, right);
    }

#pragma warning restore 1591
    #endregion Operators
}