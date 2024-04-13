using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PulseAndPower.BusinessLogic.Infrastructure;
using PulseAndPower.BusinessLogic.Services.Interfaces;

namespace PulseAndPower.WebApp.Attributes;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class AuthSidAttribute : Attribute, IAsyncActionFilter
{
    private const string AuthSidHeader = "X-AuthSid";
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(AuthSidHeader, out var extractedAuthSid))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "Auth sid was not provided"
            };
            return;
        }

        var service = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();
        var sidEntity = await service.ValidateSid(extractedAuthSid);
        var user = await service.GetUser(sidEntity.UserId);
        context.HttpContext.Response.Headers[AuthSidHeader] = extractedAuthSid;
        
        GlobalContext.UserId = user.Id;
        GlobalContext.UserStatus = user.Status;
        GlobalContext.IsVerifiedSession = sidEntity.IsVerified;
        GlobalContext.Sid = Guid.Parse(extractedAuthSid);
        
        await next();
    }
}