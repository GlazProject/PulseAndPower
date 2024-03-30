using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PulseAndPower.Attributes;
using PulseAndPower.Models.Generated;

namespace PulseAndPower.Controllers;

[AuthSid]
[ApiController]
[Route("/api/store")]
public class StoreController : ControllerBase
{ 
    /// <summary>
    /// Place an order for a subscription based on previous order
    /// </summary>
    /// <param name="previousOrderId"></param>
    /// <response code="200">successful operation</response>
    [HttpPut]
    [Route("order/{previousOrderId}")]
    public virtual IActionResult RepeatOrder([FromRoute][Required]string previousOrderId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Place an order for a subscription
    /// </summary>
    /// <remarks>Place a new order in the store with payment confirmation</remarks>
    /// <param name="body"></param>
    /// <response code="200">successful operation</response>
    [HttpPut]
    [Route("order")]
    public virtual IActionResult NewOrder([FromBody]StoreOrderBody body)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get all orders for user
    /// </summary>
    /// <response code="200">successful operation</response>
    /// <response code="400">Bad request</response>
    /// <response code="403">Authentication failed</response>
    /// <response code="500">Server error</response>
    [HttpGet]
    [Route("orders")]
    public virtual IActionResult GetOrders()
    {
        throw new NotImplementedException();
    }

    
}