using Vostok.Configuration.Abstractions.Attributes;

namespace PulseAndPower.BusinessLogic.Settings;

public class MongoSettings
{
    [Secret]
    public string MongoConnectionString { get; set; } = "mongodb://localhost:27017";
    
    public string DatabaseName { get; set; } = "PulseAndPower";
    public string SidCollectionName { get; set; } = "sessions";
    public string UsersCollectionName { get; set; } = "users";
    public string VerificationCodesCollectionName { get; set; } = "codes";
    public string AddressesCollectionName { get; set; } = "addresses";
}