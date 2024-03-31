using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PulseAndPower.Attributes;
using PulseAndPower.Models.Request;
using PulseAndPower.Models.Results;

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
    public Task<ActionResult> RepeatOrder([FromRoute][Required] string previousOrderId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Place an order for a subscription
    /// </summary>
    /// <remarks>Place a new order in the store with payment confirmation</remarks>
    /// <param name="request"></param>
    /// <response code="200">successful operation</response>
    [HttpPut]
    [Route("order")]
    public Task<ActionResult> NewOrder([FromBody] OrderRequest request)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get all orders for user
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    [Route("orders")]
    public Task<ActionResult<GetOrdersResult>> GetOrders()
    {
        throw new NotImplementedException();
    }
}