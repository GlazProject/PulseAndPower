namespace PulseAndPower.Models.Common;

public class User
{
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public string Phone { get; set; }

    public List<Address> FavouritePlaces { get; set; }
}