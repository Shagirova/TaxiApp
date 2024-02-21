using MediatR;
using TaxiApp.Modules.DriverModule.Models;

namespace TaxiApp.Modules.DriverModule.Handlers.Update;

public class UpdateDriverCommand : IRequest<bool>
{
    public UpdateDriverCommand(UpdateDriverRequest driver)
    {
        Driver = driver;
    }

    public UpdateDriverRequest Driver { get; }
}