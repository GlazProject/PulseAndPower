namespace PulseAndPower.Models.Common;

public class User
{
    /// <summary>
    /// User ID. Server will rewrite this field on user creating
    /// </summary>
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    /// <summary>
    /// Phone with 8 at the beginning
    /// </summary>
    public string Phone { get; set; }

    public List<Address> FavouritePlaces { get; set; }
}