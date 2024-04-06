using Vostok.Context;

namespace PulseAndPower.BusinessLogic.Infrastructure;

public static class GlobalContext
{
    public static Guid UserId
    {
        get => FlowingContext.Properties.Get<Guid>(nameof(UserId));
        set => FlowingContext.Properties.Set(nameof(UserId), value);
    }
    
    public static Guid Sid
    {
        get => FlowingContext.Properties.Get<Guid>(nameof(Sid));
        set => FlowingContext.Properties.Set(nameof(Sid), value);
    }
}