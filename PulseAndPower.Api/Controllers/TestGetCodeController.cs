using Microsoft.AspNetCore.Mvc;
using PulseAndPower.Attributes;
using PulseAndPower.BusinessLogic.Infrastructure;
using PulseAndPower.BusinessLogic.Services.Interfaces;

namespace PulseAndPower.Controllers;

[Route("api/test")]
public class TestGetCodeController: ControllerBase
{
    private readonly IAuthDatabaseDriver driver;

    public TestGetCodeController(IAuthDatabaseDriver driver)
    {
        this.driver = driver;
    }
    
    /// <summary>
    /// Get verification code
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    [AuthSid]
    [Route("verificationCode")]
    public async Task<ActionResult<string>> GetVerificationCode() => 
        Ok(await driver.GetVerificationCodeOrDefault(GlobalContext.Sid));
}