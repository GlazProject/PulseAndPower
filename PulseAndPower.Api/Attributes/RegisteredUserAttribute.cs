using Microsoft.AspNetCore.Mvc.Filters;
using PulseAndPower.BusinessLogic.Exceptions;
using PulseAndPower.BusinessLogic.Infrastructure;
using PulseAndPower.BusinessLogic.Models.Common;

namespace PulseAndPower.Attributes;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class RegisteredUserAttribute: Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (GlobalContext.UserStatus != UserStatus.Activated)
            throw new ForbiddenException("User is not registered yet");

        await next();
    }
}