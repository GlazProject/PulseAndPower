using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PulseAndPower.BusinessLogic.Models.Common;

public class Subscription
{
    [BsonRepresentation(BsonType.String)]
    public TimeOfDay? TimeOfDay { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public TrainingType? Options { get; set; }

    public int Duration { get; set; }
}