using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PulseAndPower.Auth.Services.Interfaces;

namespace PulseAndPower.Attributes;

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

        await context.HttpContext.RequestServices.GetRequiredService<IAuthSidService>().ValidateSid(extractedAuthSid);
        await next();
    }
}