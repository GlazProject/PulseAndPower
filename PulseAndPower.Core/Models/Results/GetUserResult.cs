using PulseAndPower.BusinessLogic.Models.Common;

namespace PulseAndPower.BusinessLogic.Models.Results;

public class GetUserResult
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public string Phone { get; set; }

    public Dictionary<string, Address> FavouritePlaces { get; set; }
}