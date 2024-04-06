using Microsoft.AspNetCore.Http;
using PulseAndPower.BusinessLogic.Models.Request;
using PulseAndPower.Models.Request;

namespace PulseAndPower.BusinessLogic.Services.Interfaces;

public interface IAuthService
{
    Task SendVerificationCode(HttpContext context, SendVerificationCodeRequest request);

    Task ValidateVerificationCode(ConfirmCodeRequest request);

    Task Logout(HttpContext context);
    
    Task<Guid> ValidateSid(string sid);
}