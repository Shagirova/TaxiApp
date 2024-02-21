using MediatR;
using TaxiApp.Data;

namespace TaxiApp.Modules.DriverModule.Handlers.GetAll;
public class GetAllDriversQuery : IRequest<IReadOnlyCollection<Driver>>
{

}