using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PulseAndPower.Attributes;
using PulseAndPower.Models.Generated;

namespace PulseAndPower.Controllers;

[AuthSid]
[ApiController]
[Route("/api/user")]
public class UserController : ControllerBase
{ 
    /// <summary>
    /// Delete favourite place for user
    /// </summary>
    /// <param name="addressGuid"></param>
    /// <response code="200">successful operation</response>
    [HttpDelete]
    [Route("favouritePlaces/{addressGuid}")]
    public virtual IActionResult DeleteFavouritePlace([FromRoute][Required] string addressGuid)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Add new favourite place for user
    /// </summary>
    /// <param name="addressGuid"></param>
    /// <response code="200">successful operation</response>
    [HttpPut]
    [Route("favouritePlaces/{addressGuid}")]
    public virtual IActionResult AddFavouritePlace([FromRoute][Required] string addressGuid)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get favourite places for user
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    [Route("favouritePlaces")]
    public virtual IActionResult GetFavouritePlaces()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get user info
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    public virtual IActionResult GetUserInfo()
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
    public virtual IActionResult PatchUserInfo([FromBody] User body)
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
    [Route("")]
    public virtual IActionResult CreateUser([FromBody]User body)
    {
        throw new NotImplementedException();
    }
}