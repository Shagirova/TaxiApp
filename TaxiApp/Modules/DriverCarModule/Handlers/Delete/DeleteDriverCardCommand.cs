using MediatR;
using TaxiApp.Modules.DriverCarModule.Models;

namespace TaxiApp.Modules.DriverCarModule.Handlers.Delete;

public class DeleteDriverCarCommand : IRequest<bool>
{
    public DeleteDriverCarCommand(DeleteDriverCarRequest driverCarRequest)
    {
        DriverCarRequest = driverCarRequest;
    }

    public DeleteDriverCarRequest DriverCarRequest { get; }
}