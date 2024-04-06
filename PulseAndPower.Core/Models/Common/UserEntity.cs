using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PulseAndPower.BusinessLogic.Models.Common;

public class UserEntity
{
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public string Phone { get; set; }

    [BsonRepresentation(BsonType.String)]
    public List<Guid> FavouritePlaces { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public UserStatus Status { get; set; }
}