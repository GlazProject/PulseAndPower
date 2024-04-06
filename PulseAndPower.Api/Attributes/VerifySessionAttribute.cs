using Microsoft.AspNetCore.Mvc.Filters;
using PulseAndPower.BusinessLogic.Exceptions;
using PulseAndPower.BusinessLogic.Infrastructure;

namespace PulseAndPower.Attributes;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class VerifySessionAttribute: Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!GlobalContext.IsVerifiedSession)
            throw new ForbiddenException("User is not registered yet");

        await next();
    }
}