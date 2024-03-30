﻿using Microsoft.AspNetCore.Mvc;

namespace PulseAndPower.Controllers;

[ApiController]
[Route("/api/store")]
public class StoreInfoController: ControllerBase
{
    /// <summary>
    /// Return list of places where sport center exists
    /// </summary>
    /// <response code="200">successful operation</response>
    [HttpGet]
    [Route("places")]
    public virtual IActionResult GetPlaces()
    {
        throw new NotImplementedException();
    }
}