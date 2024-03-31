namespace PulseAndPower.BusinessLogic.Infrastructure;

public static class GlobalContext
{
    public static Guid UserId {
        get => Guid.NewGuid();
        set => value.ToString();
    }
}