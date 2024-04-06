namespace PulseAndPower.Models.Common;

public class Subscription
{
    public TimeOfDay? TimeOfDay { get; set; }
    
    public TrainingType? Options { get; set; }

    public int Duration { get; set; }
}