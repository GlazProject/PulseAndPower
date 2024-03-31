using PulseAndPower.Models.Common;

namespace PulseAndPower.Models.Request;

public class OrderRequest
{ 
    public string PaymentInfo { get; set; }
    
    public TimeOfDay? TimeOfDay { get; set; }
    
    public TrainingType? Options { get; set; }

    public int Duration { get; set; }
}