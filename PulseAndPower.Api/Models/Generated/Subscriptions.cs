using System.Runtime.Serialization;
using System.Text;

namespace PulseAndPower.Models.Generated;

/// <summary>
/// 
/// </summary>
[DataContract]
public class Subscriptions : IEquatable<Subscriptions>
{ 
    /// <summary>
    /// Gets or Sets TimeOfDay
    /// </summary>

    [DataMember(Name="timeOfDay")]
    public List<TimeOfDay> TimeOfDay { get; set; }

    /// <summary>
    /// Gets or Sets Options
    /// </summary>

    [DataMember(Name="options")]
    public List<Options> Options { get; set; }

    /// <summary>
    /// Gets or Sets Duration
    /// </summary>

    [DataMember(Name="duration")]
    public List<Duration> Duration { get; set; }

    /// <summary>
    /// Gets or Sets _Subscriptions
    /// </summary>

    [DataMember(Name="subscriptions")]
    public List<Subscription> _Subscriptions { get; set; }

    /// <summary>
    /// Returns the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("class Subscriptions {\n");
        sb.Append("  TimeOfDay: ").Append(TimeOfDay).Append("\n");
        sb.Append("  Options: ").Append(Options).Append("\n");
        sb.Append("  Duration: ").Append(Duration).Append("\n");
        sb.Append("  _Subscriptions: ").Append(_Subscriptions).Append("\n");
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
        return obj.GetType() == GetType() && Equals((Subscriptions)obj);
    }

    /// <summary>
    /// Returns true if Subscriptions instances are equal
    /// </summary>
    /// <param name="other">Instance of Subscriptions to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(Subscriptions other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return 
            (
                TimeOfDay == other.TimeOfDay ||
                TimeOfDay != null &&
                TimeOfDay.SequenceEqual(other.TimeOfDay)
            ) && 
            (
                Options == other.Options ||
                Options != null &&
                Options.SequenceEqual(other.Options)
            ) && 
            (
                Duration == other.Duration ||
                Duration != null &&
                Duration.SequenceEqual(other.Duration)
            ) && 
            (
                _Subscriptions == other._Subscriptions ||
                _Subscriptions != null &&
                _Subscriptions.SequenceEqual(other._Subscriptions)
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
            if (TimeOfDay != null)
                hashCode = hashCode * 59 + TimeOfDay.GetHashCode();
            if (Options != null)
                hashCode = hashCode * 59 + Options.GetHashCode();
            if (Duration != null)
                hashCode = hashCode * 59 + Duration.GetHashCode();
            if (_Subscriptions != null)
                hashCode = hashCode * 59 + _Subscriptions.GetHashCode();
            return hashCode;
        }
    }

    #region Operators
#pragma warning disable 1591

    public static bool operator ==(Subscriptions left, Subscriptions right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Subscriptions left, Subscriptions right)
    {
        return !Equals(left, right);
    }

#pragma warning restore 1591
    #endregion Operators
}