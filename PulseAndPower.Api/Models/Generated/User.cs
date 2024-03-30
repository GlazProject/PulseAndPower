using System.Runtime.Serialization;
using System.Text;

namespace PulseAndPower.Models.Generated;

public class User : IEquatable<User>
{ 
    /// <summary>
    /// Gets or Sets Id
    /// </summary>

    [DataMember(Name="id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets FirstName
    /// </summary>

    [DataMember(Name="firstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or Sets LastName
    /// </summary>

    [DataMember(Name="lastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or Sets Patronymic
    /// </summary>

    [DataMember(Name="patronymic")]
    public string Patronymic { get; set; }

    /// <summary>
    /// Gets or Sets Phone
    /// </summary>

    [DataMember(Name="phone")]
    public string Phone { get; set; }

    /// <summary>
    /// Gets or Sets FavouritePlaces
    /// </summary>

    [DataMember(Name="favouritePlaces")]
    public List<Address> FavouritePlaces { get; set; }

    /// <summary>
    /// Returns the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("class User {\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  FirstName: ").Append(FirstName).Append("\n");
        sb.Append("  LastName: ").Append(LastName).Append("\n");
        sb.Append("  Patronymic: ").Append(Patronymic).Append("\n");
        sb.Append("  Phone: ").Append(Phone).Append("\n");
        sb.Append("  FavouritePlaces: ").Append(FavouritePlaces).Append("\n");
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
        return obj.GetType() == GetType() && Equals((User)obj);
    }

    /// <summary>
    /// Returns true if User instances are equal
    /// </summary>
    /// <param name="other">Instance of User to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(User other)
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
                FirstName == other.FirstName ||
                FirstName != null &&
                FirstName.Equals(other.FirstName)
            ) && 
            (
                LastName == other.LastName ||
                LastName != null &&
                LastName.Equals(other.LastName)
            ) && 
            (
                Patronymic == other.Patronymic ||
                Patronymic != null &&
                Patronymic.Equals(other.Patronymic)
            ) && 
            (
                Phone == other.Phone ||
                Phone != null &&
                Phone.Equals(other.Phone)
            ) && 
            (
                FavouritePlaces == other.FavouritePlaces ||
                FavouritePlaces != null &&
                FavouritePlaces.SequenceEqual(other.FavouritePlaces)
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
            if (FirstName != null)
                hashCode = hashCode * 59 + FirstName.GetHashCode();
            if (LastName != null)
                hashCode = hashCode * 59 + LastName.GetHashCode();
            if (Patronymic != null)
                hashCode = hashCode * 59 + Patronymic.GetHashCode();
            if (Phone != null)
                hashCode = hashCode * 59 + Phone.GetHashCode();
            if (FavouritePlaces != null)
                hashCode = hashCode * 59 + FavouritePlaces.GetHashCode();
            return hashCode;
        }
    }

    #region Operators
#pragma warning disable 1591

    public static bool operator ==(User left, User right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(User left, User right)
    {
        return !Equals(left, right);
    }

#pragma warning restore 1591
    #endregion Operators
}