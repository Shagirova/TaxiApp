using MediatR;

namespace TaxiApp.Modules.DriverModule.Handlers.Delete
{
    public class DeleteDriverCommand : IRequest<bool>
    {
        public DeleteDriverCommand(int idDriver)
        {
            IdDriver = idDriver;
        }
        public int IdDriver { get; }
    }
}