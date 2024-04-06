using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;

namespace PulseAndPower.BusinessLogic.Infrastructure;

public class StringGuidSerializer: GuidSerializer
{
    public StringGuidSerializer() : base(BsonType.String)
    {
    }
}