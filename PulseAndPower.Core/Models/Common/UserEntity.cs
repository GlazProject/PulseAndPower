namespace PulseAndPower.BusinessLogic.Models.Common;

public class UserEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public string Phone { get; set; }

    public List<Guid> FavouritePlaces { get; set; }
    
    public UserStatus Status { get; set; }
}