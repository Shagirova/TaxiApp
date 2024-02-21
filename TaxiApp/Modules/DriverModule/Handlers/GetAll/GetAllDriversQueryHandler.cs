using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Data;

namespace TaxiApp.Modules.DriverModule.Handlers.GetAll;

public class GetAllDriversQueryHandler : IRequestHandler<GetAllDriversQuery, IReadOnlyCollection<Driver>>
{
    private readonly TaxiAppDataContext _dbContext;
    public GetAllDriversQueryHandler(TaxiAppDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<Driver>> Handle(GetAllDriversQuery query, CancellationToken cancellationToken)
    {
        return await _dbContext.Driver.ToArrayAsync(cancellationToken);
    }
}
