using System.Runtime.Serialization;
using System.Text;

namespace PulseAndPower.Models.Generated;

public class Address : IEquatable<Address>
{ 
    /// <summary>
    /// Gets or Sets Id
    /// </summary>

    [DataMember(Name="id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets Street
    /// </summary>

    [DataMember(Name="street")]
    public string Street { get; set; }

    /// <summary>
    /// Gets or Sets City
    /// </summary>

    [DataMember(Name="city")]
    public string City { get; set; }

    /// <summary>
    /// Gets or Sets State
    /// </summary>

    [DataMember(Name="state")]
    public string State { get; set; }

    /// <summary>
    /// Gets or Sets Coordinates
    /// </summary>

    [DataMember(Name="coordinates")]
    public string Coordinates { get; set; }

    /// <summary>
    /// Returns the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("class Address {\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Street: ").Append(Street).Append("\n");
        sb.Append("  City: ").Append(City).Append("\n");
        sb.Append("  State: ").Append(State).Append("\n");
        sb.Append("  Coordinates: ").Append(Coordinates).Append("\n");
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
        return obj.GetType() == GetType() && Equals((Address)obj);
    }

    /// <summary>
    /// Returns true if Address instances are equal
    /// </summary>
    /// <param name="other">Instance of Address to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(Address other)
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
                Street == other.Street ||
                Street != null &&
                Street.Equals(other.Street)
            ) && 
            (
                City == other.City ||
                City != null &&
                City.Equals(other.City)
            ) && 
            (
                State == other.State ||
                State != null &&
                State.Equals(other.State)
            ) && 
            (
                Coordinates == other.Coordinates ||
                Coordinates != null &&
                Coordinates.Equals(other.Coordinates)
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
            if (Street != null)
                hashCode = hashCode * 59 + Street.GetHashCode();
            if (City != null)
                hashCode = hashCode * 59 + City.GetHashCode();
            if (State != null)
                hashCode = hashCode * 59 + State.GetHashCode();
            if (Coordinates != null)
                hashCode = hashCode * 59 + Coordinates.GetHashCode();
            return hashCode;
        }
    }

    #region Operators
#pragma warning disable 1591

    public static bool operator ==(Address left, Address right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Address left, Address right)
    {
        return !Equals(left, right);
    }

#pragma warning restore 1591
    #endregion Operators
}