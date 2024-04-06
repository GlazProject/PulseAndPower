using Microsoft.AspNetCore.Http;
using PulseAndPower.BusinessLogic.Exceptions;
using PulseAndPower.BusinessLogic.Infrastructure;
using PulseAndPower.BusinessLogic.Models.Common;
using PulseAndPower.BusinessLogic.Models.Request;
using PulseAndPower.BusinessLogic.Services.Interfaces;
using PulseAndPower.Models.Request;
using Vostok.Logging.Abstractions;

namespace PulseAndPower.BusinessLogic.Services;

public class AuthService: IAuthService
{
    private const string AuthSidHeader = "X-AuthSid";
    private static readonly Random Random = Random.Shared;

    private readonly ILog log;
    private readonly IAuthDatabaseDriver driver;
    
    public AuthService(IAuthDatabaseDriver driver, ILog log)
    {
        this.driver = driver;
        this.log = log;
    }

    public async Task SendVerificationCode(HttpContext context, SendVerificationCodeRequest request)
    {
        log.Info($"Sending verification code for phone {request.NormalizedPhone}");
        var user = await driver.GetOrCreateUser(Helpers.NormalizePhone(request.NormalizedPhone));
        var sidEntity = await driver.CreateSession(user.Id);
        await driver.CreateOrUpdateVerificationCode(user.Id, NewCode);
        context.Response.Headers[AuthSidHeader] = sidEntity.Id.ToString();
    }

    public async Task ValidateVerificationCode(ConfirmCodeRequest request)
    {
        var userId = GlobalContext.UserId;
        var code = await driver.GetVerificationCodeOrDefault(userId);
        if (!string.Equals(code, request.Code))
            throw new BadRequestException("Incorrect verification code");

        await driver.DeleteVerificationCode(userId);
        await driver.UpdateUser(userId, user =>
        {
            if (user.IsActivated == UserStatus.CodeSent)
                user.IsActivated = UserStatus.PhoneVerified;
        });
    }

    public Task Logout(HttpContext context)
    {
        context.Response.Headers.Remove(AuthSidHeader);
        return driver.DeleteSession(GlobalContext.Sid);
    }

    public async Task<Guid> ValidateSid(string sid)
    {
        if (!Guid.TryParse(sid, out var id))
            throw ExceptionsHelper.Unauthenticated;

        var entity = await driver.GetSessionOrDefault(id);
        return entity?.UserId ?? throw ExceptionsHelper.Unauthenticated;
    }

    private static string NewCode => Random.NextInt64(1000, 9999).ToString();
}