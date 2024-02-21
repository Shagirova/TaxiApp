using MediatR;
using TaxiApp.Modules.DriverModule.Models;

namespace TaxiApp.Modules.DriverModule.Handlers.GetAllFullInfo;
public class GetAllFullInfoQuery : IRequest<IReadOnlyCollection<GetDriverFullInfoResponse>>
{

}