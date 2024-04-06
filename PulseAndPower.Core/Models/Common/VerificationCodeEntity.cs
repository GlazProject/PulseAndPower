using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PulseAndPower.BusinessLogic.Models.Common;

public class VerificationCodeEntity
{
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    public string? VerificationCode { get; set; }
}