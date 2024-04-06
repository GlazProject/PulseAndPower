using Microsoft.AspNetCore.Http;
using PulseAndPower.BusinessLogic.Models.Common;
using PulseAndPower.BusinessLogic.Models.Request;

namespace PulseAndPower.BusinessLogic.Services.Interfaces;

public interface IAuthService
{
    Task SendVerificationCode(HttpContext context, SendVerificationCodeRequest request);

    Task ValidateVerificationCode(ConfirmCodeRequest request);

    Task Logout(HttpContext context);
    
    Task<SidEntity> ValidateSid(string sid);
    Task<UserEntity> GetUser(Guid userId);
}