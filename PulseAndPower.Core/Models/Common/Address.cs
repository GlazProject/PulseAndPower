using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PulseAndPower.BusinessLogic.Models.Common;

public class Address
{
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string Street { get; set; }
    
    public string City { get; set; }
    
    public string State { get; set; }
}