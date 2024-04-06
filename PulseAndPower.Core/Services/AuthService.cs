using Microsoft.AspNetCore.Http;
using PulseAndPower.BusinessLogic.Exceptions;
using PulseAndPower.BusinessLogic.Infrastructure;
using PulseAndPower.BusinessLogic.Models.Common;
using PulseAndPower.BusinessLogic.Models.Request;
using PulseAndPower.BusinessLogic.Services.Interfaces;
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
        await driver.CreateOrUpdateVerificationCode(sidEntity.Id, NewCode);
        context.Response.Headers[AuthSidHeader] = sidEntity.Id.ToString();
    }

    public async Task ValidateVerificationCode(ConfirmCodeRequest request)
    {
        var sid = GlobalContext.Sid;
        var userId = GlobalContext.UserId;
        
        var code = await driver.GetVerificationCodeOrDefault(sid);
        if (!string.Equals(code, request.Code))
            throw new BadRequestException("Incorrect verification code");

        await driver.SetSessionAsVerified(sid);
        await driver.DeleteVerificationCode(sid);
        await driver.UpdateUser(userId, user =>
        {
            if (user.Status == UserStatus.CodeSent)
                user.Status = UserStatus.PhoneVerified;
        });
    }

    public Task Logout(HttpContext context)
    {
        context.Response.Headers.Remove(AuthSidHeader);
        return driver.DeleteSession(GlobalContext.Sid);
    }

    public async Task<SidEntity> ValidateSid(string sid)
    {
        if (!Guid.TryParse(sid, out var id))
            throw ExceptionsHelper.Unauthenticated;

        return await driver.GetSessionOrDefault(id) ?? throw ExceptionsHelper.Unauthenticated;
    }

    public async Task<UserEntity> GetUser(Guid userId) => 
        await driver.GetUserEntity(userId) ?? throw new BadRequestException("User for session not found");

    private static string NewCode => Random.NextInt64(1000, 9999).ToString();
}