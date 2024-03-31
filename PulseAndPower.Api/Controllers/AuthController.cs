using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PulseAndPower.Attributes;

namespace PulseAndPower.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{ 
    /// <summary>
    /// Send SMS verification code
    /// </summary>
    /// <remarks>Sends an SMS verification code to the specified phone number</remarks>
    /// <param name="normalizedNumber">The normalized phone number with country code +7</param>
    /// <response code="200">SMS sent successfully</response>
    [HttpPost]
    [Route("phone/{normalizedNumber}")]
    public Task<IActionResult> SendVerificationCode([FromRoute][Required] string normalizedNumber)
    { 
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Confirm phone with received code
    /// </summary>
    /// <remarks>Send new authSid, if code is correct</remarks>
    /// <param name="code">Code received from sms</param>
    /// <response code="200">Successful operation</response>
    [AuthSid]
    [HttpPost]
    [Route("confirmPhone/{code}")]
    public Task<IActionResult> ConfirmPhoneCode([FromQuery][Required] string code)
    { 
        throw new NotImplementedException();
    }

    /// <summary>
    /// Logs out current logged in user session
    /// </summary>
    /// <response code="200">successful operation</response>
    [AuthSid]
    [HttpGet]
    [Route("logout")]
    public Task<IActionResult> LogOut()
    { 
        throw new NotImplementedException();
    }
}