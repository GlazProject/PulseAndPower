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
    /// Place an order for a subscription. If you want to reorder old order post new order with same parameters.
    /// </summary>
    /// <remarks>Place a new order in the store with payment confirmation</remarks>
    /// <param name="request">Order request</param>
    /// <response code="200">successful operation</response>
    [HttpPost]
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