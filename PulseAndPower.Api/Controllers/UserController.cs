using Microsoft.AspNetCore.Mvc;
using PulseAndPower.Attributes;
using PulseAndPower.BusinessLogic.Models.Request;
using PulseAndPower.BusinessLogic.Models.Results;
using PulseAndPower.BusinessLogic.Services.Interfaces;

namespace PulseAndPower.Controllers;

[AuthSid]
[VerifySession]
[ApiController]
[Route("/api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService service;

    public UserController(IUserService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Add new favourite place for user
    /// </summary>
    /// <param name="request">Request with information about favourite place</param>
    /// <response code="200">successful operation</response>
    [HttpPost]
    [RegisteredUser]
    [Route("favouritePlaces")]
    public async Task<ActionResult<GetPlacesResult>> SetFavouritePlaces([FromBody] PlacesRequest request) =>
        Ok(await service.SetFavouritePlaces(request));

    /// <summary>
    /// Get favourite places for user
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    [RegisteredUser]
    [Route("favouritePlaces")]
    public async Task<ActionResult<GetPlacesResult>> GetFavouritePlaces() => Ok(await service.GetFavouritePlaces());

    /// <summary>
    /// Get user info
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    [RegisteredUser]
    public async Task<ActionResult<GetUserResult>> GetUserInfo() => Ok(await service.GetUserInfo());

    /// <summary>
    /// Create user
    /// </summary>
    /// <remarks>This can only be done by the logged in user.</remarks>
    /// <param name="request">Created user object</param>
    /// <response code="200">successful operation</response>
    [HttpPut]
    public async Task<ActionResult<GetUserResult>> CreateUser([FromBody] UserRequest request) => 
        Ok(await service.CreateUser(request));
}