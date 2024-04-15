using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PulseAndPower.BusinessLogic.Models.Common;

public class Order
{
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public Guid UserId { get; set; }
    
    public DateTime Date { get; set; }

    [BsonIgnore]
    public bool IsExpired => Date.AddMonths(Subscription?.Duration ??  int.MaxValue) > DateTime.Now;
    
    public Subscription Subscription { get; set; }
}