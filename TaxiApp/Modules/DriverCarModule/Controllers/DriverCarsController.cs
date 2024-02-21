using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Modules.DriverCarModule.Handlers.Create;
using TaxiApp.Modules.DriverCarModule.Handlers.Delete;
using TaxiApp.Modules.DriverCarModule.Models;

namespace TaxiApp.Modules.DriverCarModule.Controllers;

[Route("DriverCars")]
[ApiController]
public class DriverCarsController : Controller
{
    private readonly IMediator _mediator;

    public DriverCarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Post([FromBody] CreateDriverCarRequest driverCarRequest)
    {
        var created = await _mediator.Send(new CreateDriverCarCommand(driverCarRequest), HttpContext.RequestAborted);
        return Ok(created);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteDriverCarRequest deleteDriverCarRequest)
    {
        var deleted = await _mediator.Send(new DeleteDriverCarCommand(deleteDriverCarRequest), HttpContext.RequestAborted);
        return Ok(deleted);
    }
}
