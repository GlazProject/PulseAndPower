using System.Security.Authentication;

namespace PulseAndPower.BusinessLogic.Exceptions;

public static class ExceptionsHelper
{
    public static Exception Unauthenticated => new AuthenticationException("Unauthenticated user");
}