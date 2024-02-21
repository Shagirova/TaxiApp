using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Data;

namespace TaxiApp.Modules.Car.Handlers.DeleteMassive;

public class DeleteCarsMassivelyCommandHandler : IRequestHandler<DeleteCarsMassivelyCommand, bool>
{
    private readonly TaxiAppDataContext _dbContext;
    public DeleteCarsMassivelyCommandHandler(TaxiAppDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(DeleteCarsMassivelyCommand command, CancellationToken cancellation)
    {
        await _dbContext.Car.Where(x => command.IdsCars.Contains(x.IdCar)).ExecuteDeleteAsync(cancellation);
        return true;
    }
}
