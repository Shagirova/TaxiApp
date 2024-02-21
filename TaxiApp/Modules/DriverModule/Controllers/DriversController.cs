using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Modules.DriverModule.Handlers.Create;
using TaxiApp.Modules.DriverModule.Handlers.Delete;
using TaxiApp.Modules.DriverModule.Handlers.GetAll;
using TaxiApp.Modules.DriverModule.Handlers.GetAllFullInfo;
using TaxiApp.Modules.DriverModule.Handlers.Update;
using TaxiApp.Modules.DriverModule.Models;

namespace TaxiApp.Modules.DriverModule.Controllers;

[Route("Drivers")]
[ApiController]
public class DriversController : Controller
{
    private readonly IMediator _mediator;

    public DriversController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Post([FromBody] CreateDriverRequest driver)
    {
        var created = await _mediator.Send(new CreateDriverCommand(driver), HttpContext.RequestAborted);
        return Ok(created);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Put([FromBody] UpdateDriverRequest driver)
    {
        var updated = await _mediator.Send(new UpdateDriverCommand(driver), HttpContext.RequestAborted);
        return Ok(updated);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] int idDriver)
    {
        var deleted = await _mediator.Send(new DeleteDriverCommand(idDriver), HttpContext.RequestAborted);
        return Ok(deleted);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var drivers = await _mediator.Send(new GetAllDriversQuery(), HttpContext.RequestAborted);
        return Ok(drivers);
    }

    [HttpGet("GetAllFullInfo")]
    public async Task<IActionResult> GetAllFullInfo()
    {
        var drivers = await _mediator.Send(new GetAllFullInfoQuery(), HttpContext.RequestAborted);
        return Ok(drivers);
    }
}
