namespace PulseAndPower.BusinessLogic.Exceptions;

public static class ExceptionsHelper
{
    public static ApplicationException Unauthenticated => new("Unauthenticated user");
}