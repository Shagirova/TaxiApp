using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Modules.Car.Handlers.DeleteMassive;

namespace TaxiApp.Modules.Car.Controllers;

[Route("Cars")]
[ApiController]
public class CarsController : Controller
{
    private readonly IMediator _mediator;
    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("DeleteMassive")]
    public async Task<IActionResult> Delete([FromBody] int[] idsCars)
    {
        var deleted = await _mediator.Send(new DeleteCarsMassivelyCommand(idsCars), HttpContext.RequestAborted);
        return Ok(deleted);
    }
}