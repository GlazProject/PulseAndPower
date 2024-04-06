namespace PulseAndPower.BusinessLogic.Exceptions;

public class BadRequestException: Exception
{
    public BadRequestException(string? message) : base(message)
    {
    }
}