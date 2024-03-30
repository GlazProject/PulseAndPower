namespace PulseAndPower.Auth.Services.Interfaces;

public interface IAuthSidService
{
    Task ValidateSid(string sid);
}