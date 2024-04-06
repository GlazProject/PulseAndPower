namespace PulseAndPower.Models.Common;

public class Order
{
    public Guid Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public Subscription Subscription { get; set; }
}