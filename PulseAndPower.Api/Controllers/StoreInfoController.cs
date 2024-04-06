using Microsoft.AspNetCore.Mvc;
using PulseAndPower.BusinessLogic.Models.Results;
using PulseAndPower.BusinessLogic.Services.Interfaces;

namespace PulseAndPower.Controllers;

[ApiController]
[Route("/api/store")]
public class StoreInfoController: ControllerBase
{
    private readonly IStoreInfoService service;

    public StoreInfoController(IStoreInfoService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Return list of places where sport center exists
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    [Route("places")]
    public async Task<ActionResult<GetPlacesResult>> GetPlaces() => Ok(await service.GetAllPlaces());
}