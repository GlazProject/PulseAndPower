using MongoDB.Bson.Serialization.Attributes;
using PulseAndPower.BusinessLogic.Infrastructure;

namespace PulseAndPower.BusinessLogic.Models.Common;

public class Address
{
    [BsonSerializer(typeof(StringGuidSerializer))]
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string Street { get; set; }
    
    public string City { get; set; }
    
    public string State { get; set; }
}