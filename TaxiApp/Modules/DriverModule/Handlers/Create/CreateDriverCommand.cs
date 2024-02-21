using MediatR;
using TaxiApp.Modules.DriverModule.Models;

namespace TaxiApp.Modules.DriverModule.Handlers.Create;

public class CreateDriverCommand : IRequest<int>
{
    public CreateDriverCommand(CreateDriverRequest driver)
    {
        Driver = driver;
    }
    public CreateDriverRequest Driver { get; }
}