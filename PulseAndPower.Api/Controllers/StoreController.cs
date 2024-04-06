using Microsoft.AspNetCore.Mvc;
using PulseAndPower.Attributes;
using PulseAndPower.BusinessLogic.Models.Common;
using PulseAndPower.BusinessLogic.Models.Request;
using PulseAndPower.BusinessLogic.Models.Results;
using PulseAndPower.BusinessLogic.Services.Interfaces;

namespace PulseAndPower.Controllers;

[AuthSid]
[ApiController]
[VerifySession]
[Route("/api/store")]
public class StoreController : ControllerBase
{
    private readonly IStoreService service;

    public StoreController(IStoreService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Place an order for a subscription. If you want to reorder old order post new order with same parameters.
    /// </summary>
    /// <remarks>Place a new order in the store with payment confirmation</remarks>
    /// <param name="request">Order request</param>
    /// <response code="200">successful operation</response>
    [HttpPost]
    [Route("order")]
    public async Task<ActionResult<Order>> NewOrder([FromBody] OrderRequest request) =>
        Ok(await service.CreateOrder(request));

    /// <summary>
    /// Get all orders for user
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    [Route("orders")]
    public async Task<ActionResult<GetOrdersResult>> GetOrders() => Ok(await service.GetOrders());
}