namespace PulseAndPower.BusinessLogic.Models.Common;

public class User
{
    /// <summary>
    /// User ID. Server will rewrite this field on user creating
    /// </summary>
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public string Phone { get; set; }

    public List<Address> FavouritePlaces { get; set; }
    
    public UserStatus IsActivated { get; set; }
}