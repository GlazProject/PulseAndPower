using MongoDB.Bson;

namespace PulseAndPower.BusinessLogic.Models.DB;

public class SidEntity
{
    public ObjectId Id { get; set; }
    
    public string Sid { get; set; }
    
    public Guid UserId { get; set; }
}