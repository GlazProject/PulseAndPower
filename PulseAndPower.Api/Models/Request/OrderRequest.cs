using PulseAndPower.Models.Common;

namespace PulseAndPower.Models.Request;

public class OrderRequest
{ 
    /// <summary>
    /// The time of day for training
    /// </summary>
    public TimeOfDay? TimeOfDay { get; set; }
    
    /// <summary>
    /// Selected training type
    /// </summary>
    public TrainingType? TrainingType { get; set; }

    /// <summary>
    /// Subscription duration in months
    /// </summary>
    public int Duration { get; set; }
}