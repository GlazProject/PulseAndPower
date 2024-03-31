using MongoDB.Bson.Serialization.Attributes;

namespace PulseAndPower.BusinessLogic.Models.DB;

public class SidEntity
{
    [BsonElement]
    public string Sid { get; set; }
    
    [BsonElement]
    public Guid UserId { get; set; }
}