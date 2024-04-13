using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PulseAndPower.BusinessLogic.Models.Common;
using PulseAndPower.BusinessLogic.Models.Request;
using PulseAndPower.BusinessLogic.Models.Results;
using PulseAndPower.BusinessLogic.Services.Interfaces;
using PulseAndPower.WebApp.Attributes;

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
    /// Delete favourite place for user
    /// </summary>
    /// <param name="placeId">ID of the place for deletion</param>
    /// <response code="200">successful operation</response>
    [HttpDelete]
    [Route("favouritePlaces")]
    public async Task<ActionResult<GetPlacesResult>> DeleteFavouritePlace([FromQuery, Required] Guid placeId) =>
        Ok(await service.DeleteFavouritePlace(placeId));

    /// <summary>
    /// Add new favourite place for user
    /// </summary>
    /// <param name="request">Request with information about favourite place</param>
    /// <response code="200">successful operation</response>
    [HttpPut]
    [Route("favouritePlaces")]
    public async Task<ActionResult<GetPlacesResult>> AddFavouritePlace([FromBody] PlacesRequest request) =>
        Ok(await service.AddFavouritePlace(request));

    /// <summary>
    /// Get favourite places for user
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    [Route("favouritePlaces")]
    public async Task<ActionResult<GetPlacesResult>> GetFavouritePlaces() => Ok(await service.GetFavouritePlaces());

    /// <summary>
    /// Get user info
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
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