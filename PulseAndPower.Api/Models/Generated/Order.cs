using System.Runtime.Serialization;
using System.Text;

namespace PulseAndPower.Models.Generated;

public class Order : IEquatable<Order>
{ 
    /// <summary>
    /// Gets or Sets Id
    /// </summary>

    [DataMember(Name="id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets UserId
    /// </summary>

    [DataMember(Name="userId")]
    public string UserId { get; set; }

    /// <summary>
    /// Gets or Sets SubscriptionId
    /// </summary>

    [DataMember(Name="subscriptionId")]
    public string SubscriptionId { get; set; }

    /// <summary>
    /// Gets or Sets Date
    /// </summary>

    [DataMember(Name="date")]
    public string Date { get; set; }

    /// <summary>
    /// Returns the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("class Order {\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  UserId: ").Append(UserId).Append("\n");
        sb.Append("  SubscriptionId: ").Append(SubscriptionId).Append("\n");
        sb.Append("  Date: ").Append(Date).Append("\n");
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
        return obj.GetType() == GetType() && Equals((Order)obj);
    }

    /// <summary>
    /// Returns true if Order instances are equal
    /// </summary>
    /// <param name="other">Instance of Order to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(Order other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return 
            (
                Id == other.Id ||
                Id != null &&
                Id.Equals(other.Id)
            ) && 
            (
                UserId == other.UserId ||
                UserId != null &&
                UserId.Equals(other.UserId)
            ) && 
            (
                SubscriptionId == other.SubscriptionId ||
                SubscriptionId != null &&
                SubscriptionId.Equals(other.SubscriptionId)
            ) && 
            (
                Date == other.Date ||
                Date != null &&
                Date.Equals(other.Date)
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
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (UserId != null)
                hashCode = hashCode * 59 + UserId.GetHashCode();
            if (SubscriptionId != null)
                hashCode = hashCode * 59 + SubscriptionId.GetHashCode();
            if (Date != null)
                hashCode = hashCode * 59 + Date.GetHashCode();
            return hashCode;
        }
    }

    #region Operators
#pragma warning disable 1591

    public static bool operator ==(Order left, Order right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Order left, Order right)
    {
        return !Equals(left, right);
    }

#pragma warning restore 1591
    #endregion Operators
}