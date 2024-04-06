using System.ComponentModel.DataAnnotations;
using PulseAndPower.BusinessLogic.Models.Common;

namespace PulseAndPower.BusinessLogic.Models.Request;

public class OrderRequest
{ 
    /// <summary>
    /// The time of day for training
    /// </summary>
    public TimeOfDay TimeOfDay { get; set; }
    
    /// <summary>
    /// Selected training type
    /// </summary>
    public TrainingType TrainingType { get; set; }

    /// <summary>
    /// Subscription duration in months
    /// </summary>
    [Range(1, 999)]
    public int Duration { get; set; }
}