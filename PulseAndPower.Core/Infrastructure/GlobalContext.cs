using PulseAndPower.BusinessLogic.Models.Common;
using Vostok.Context;

namespace PulseAndPower.BusinessLogic.Infrastructure;

public static class GlobalContext
{
    public static bool IsVerifiedSession
    {
        get => FlowingContext.Properties.Get<bool>(nameof(IsVerifiedSession));
        set => FlowingContext.Properties.Set(nameof(IsVerifiedSession), value);
    }
    
    public static UserStatus UserStatus
    {
        get => FlowingContext.Properties.Get<UserStatus>(nameof(UserStatus));
        set => FlowingContext.Properties.Set(nameof(UserStatus), value);
    }
    
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