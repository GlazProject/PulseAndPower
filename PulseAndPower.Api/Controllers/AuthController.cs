using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PulseAndPower.Attributes;
using PulseAndPower.BusinessLogic.Models.Request;
using PulseAndPower.BusinessLogic.Services.Interfaces;
using PulseAndPower.Models.Request;

namespace PulseAndPower.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService service;

    public AuthController(IAuthService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Send SMS verification code
    /// </summary>
    /// <remarks>Sends an SMS verification code to the specified phone number</remarks>
    /// <param name="request">Request with normalized phone number (without +7 or 8)</param>
    /// <response code="200">SMS sent successfully</response>
    [HttpPost]
    [Route("sendCode")]
    public Task SendVerificationCode([FromBody, Required] SendVerificationCodeRequest request) => 
        service.SendVerificationCode(HttpContext, request);

    /// <summary>
    /// Confirm phone with received code
    /// </summary>
    /// <remarks>Send new authSid, if code is correct</remarks>
    /// <param name="request">Request with confirmation code</param>
    /// <response code="200">Successful operation</response>
    [AuthSid]
    [HttpPost]
    [Route("confirmCode")]
    public Task ConfirmPhoneCode([FromBody, Required] ConfirmCodeRequest request) =>
        service.ValidateVerificationCode(request);

    /// <summary>
    /// Logs out current logged in user session
    /// </summary>
    /// <response code="200">successful operation</response>
    [AuthSid]
    [HttpGet]
    [Route("logout")]
    public Task LogOut() => service.Logout(HttpContext);
}