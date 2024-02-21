using MediatR;

namespace TaxiApp.Modules.Car.Handlers.DeleteMassive;

public class DeleteCarsMassivelyCommand : IRequest<bool>
{
    public DeleteCarsMassivelyCommand(int[] idsCars) 
    {
        IdsCars = idsCars;
    }
    public int[] IdsCars { get; }
}