using MediatR;
using TaxiApp.Modules.DriverCarModule.Models;

namespace TaxiApp.Modules.DriverCarModule.Handlers.Create;

public class CreateDriverCarCommand : IRequest<bool>
{
    public CreateDriverCarCommand(CreateDriverCarRequest driverCarRequest)
    {
        DriverCarRequest = driverCarRequest;
    }

    public CreateDriverCarRequest DriverCarRequest { get; } 
}