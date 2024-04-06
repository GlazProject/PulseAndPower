using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PulseAndPower.Attributes;
using PulseAndPower.BusinessLogic.Models.Common;
using PulseAndPower.BusinessLogic.Models.Results;
using PulseAndPower.Models.Request;

namespace PulseAndPower.Controllers;

[AuthSid]
[ApiController]
[Route("/api/user")]
public class UserController : ControllerBase
{
    /// <summary>
    /// Delete favourite place for user
    /// </summary>
    /// <param name="placeId">ID of the place for deletion</param>
    /// <response code="200">successful operation</response>
    [HttpDelete]
    [Route("favouritePlaces")]
    public Task<IActionResult> DeleteFavouritePlace([FromQuery, Required] Guid placeId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Add new favourite place for user
    /// </summary>
    /// <param name="request">Request with information about favourite place</param>
    /// <response code="200">successful operation</response>
    [HttpPut]
    [Route("favouritePlaces")]
    public Task<IActionResult> AddFavouritePlace([FromBody, Required] PlacesRequest request)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get favourite places for user
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    [Route("favouritePlaces")]
    public Task<ActionResult<GetPlacesResult>> GetFavouritePlaces()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get user info
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    public Task<ActionResult<User>> GetUserInfo()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Patch user
    /// </summary>
    /// <remarks>This can only be done by the logged in user.</remarks>
    /// <param name="body">New user info. May not include all fields in request</param>
    /// <response code="200">successful operation</response>
    [HttpPatch]
    public Task<ActionResult<User>> PatchUserInfo([FromBody] User body)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Create user
    /// </summary>
    /// <remarks>This can only be done by the logged in user.</remarks>
    /// <param name="body">Created user object</param>
    /// <response code="200">successful operation</response>
    [HttpPut]
    public Task<ActionResult<User>> CreateUser([FromBody] User body)
    {
        throw new NotImplementedException();
    }
}