using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Data;

namespace TaxiApp.Modules.DriverModule.Handlers.Delete
{
    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, bool>
    {
        private readonly TaxiAppDataContext _dbContext;
        public DeleteDriverCommandHandler(TaxiAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteDriverCommand command, CancellationToken cancellation)
        {
            await _dbContext.Driver.Where(x => x.IdDriver == command.IdDriver).ExecuteDeleteAsync(cancellation);
            return true;
        }
    }
}