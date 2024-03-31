namespace PulseAndPower.BusinessLogic.Settings;

public class SecretSettings
{
    public string MongoConnectionString { get; set; } = "mongodb://localhost:27017";

    public AuthSettings AuthSettings { get; set; } = new();
}