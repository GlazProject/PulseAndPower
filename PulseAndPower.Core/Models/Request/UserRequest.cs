namespace PulseAndPower.BusinessLogic.Models.Request;

public class UserRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? Patronymic { get; set; }

    public List<Guid>? FavouritePlaces { get; set; }
}