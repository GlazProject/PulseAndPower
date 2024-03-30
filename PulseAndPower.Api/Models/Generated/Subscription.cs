using System.Runtime.Serialization;
using System.Text;

namespace PulseAndPower.Models.Generated;

public class Subscription : IEquatable<Subscription>
{ 
    /// <summary>
    /// Gets or Sets TimeOfDay
    /// </summary>

    [DataMember(Name="timeOfDay")]
    public TimeOfDay TimeOfDay { get; set; }

    /// <summary>
    /// Gets or Sets Options
    /// </summary>

    [DataMember(Name="options")]
    public Options Options { get; set; }

    /// <summary>
    /// Gets or Sets Duration
    /// </summary>

    [DataMember(Name="duration")]
    public Duration Duration { get; set; }

    /// <summary>
    /// Gets or Sets Coast
    /// </summary>

    [DataMember(Name="coast")]
    public int? Coast { get; set; }

    /// <summary>
    /// Returns the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("class Subscription {\n");
        sb.Append("  TimeOfDay: ").Append(TimeOfDay).Append("\n");
        sb.Append("  Options: ").Append(Options).Append("\n");
        sb.Append("  Duration: ").Append(Duration).Append("\n");
        sb.Append("  Coast: ").Append(Coast).Append("\n");
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
        return obj.GetType() == GetType() && Equals((Subscription)obj);
    }

    /// <summary>
    /// Returns true if Subscription instances are equal
    /// </summary>
    /// <param name="other">Instance of Subscription to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(Subscription other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return 
            (
                TimeOfDay == other.TimeOfDay ||
                TimeOfDay != null &&
                TimeOfDay.Equals(other.TimeOfDay)
            ) && 
            (
                Options == other.Options ||
                Options != null &&
                Options.Equals(other.Options)
            ) && 
            (
                Duration == other.Duration ||
                Duration != null &&
                Duration.Equals(other.Duration)
            ) && 
            (
                Coast == other.Coast ||
                Coast != null &&
                Coast.Equals(other.Coast)
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
            if (Coast != null)
                hashCode = hashCode * 59 + Coast.GetHashCode();
            return hashCode;
        }
    }

    #region Operators
#pragma warning disable 1591

    public static bool operator ==(Subscription left, Subscription right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Subscription left, Subscription right)
    {
        return !Equals(left, right);
    }

#pragma warning restore 1591
    #endregion Operators
}