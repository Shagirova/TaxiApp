using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Data;

namespace TaxiApp.Modules.DriverCarModule.Handlers.Delete;

public class DeleteDriverCarCommandHandler : IRequestHandler<DeleteDriverCarCommand, bool>
{
    private readonly TaxiAppDataContext _dbContext;
    public DeleteDriverCarCommandHandler(TaxiAppDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(DeleteDriverCarCommand command, CancellationToken cancellation)
    {
        await _dbContext.DriverCar
            .Where(x => x.IdCar == command.DriverCarRequest.IdCar &&
                   x.IdDriver == command.DriverCarRequest.IdDriver)
            .ExecuteDeleteAsync(cancellation);
        return true;
    }
}