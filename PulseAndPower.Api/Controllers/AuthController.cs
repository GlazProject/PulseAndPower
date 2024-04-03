using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PulseAndPower.Attributes;
using PulseAndPower.Models.Request;

namespace PulseAndPower.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{ 
    /// <summary>
    /// Send SMS verification code
    /// </summary>
    /// <remarks>Sends an SMS verification code to the specified phone number</remarks>
    /// <param name="request">Request with normalized phone number (without +7 or 8)</param>
    /// <response code="200">SMS sent successfully</response>
    [HttpPost]
    [Route("phone")]
    public Task<IActionResult> SendVerificationCode([FromBody, Required] SendVerificationCodeRequest request)
    { 
        throw new NotImplementedException();
    }

    /// <summary>
    /// Confirm phone with received code
    /// </summary>
    /// <remarks>Send new authSid, if code is correct</remarks>
    /// <param name="request">Request with confirmation code</param>
    /// <response code="200">Successful operation</response>
    [AuthSid]
    [HttpPost]
    [Route("confirmPhone")]
    public Task<IActionResult> ConfirmPhoneCode([FromBody, Required] ConfirmCodeRequest request)
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