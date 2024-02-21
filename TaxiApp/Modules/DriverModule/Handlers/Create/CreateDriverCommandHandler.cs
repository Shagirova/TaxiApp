using AutoMapper;
using MediatR;
using TaxiApp.Data;

namespace TaxiApp.Modules.DriverModule.Handlers.Create;

public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, int>
{
    private readonly TaxiAppDataContext _dbContext;
    private readonly IMapper _mapper;
    public CreateDriverCommandHandler(TaxiAppDataContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateDriverCommand command, CancellationToken cancellationToken)
    {
        var driver = _mapper.Map<Driver>(command.Driver);
        await _dbContext.Driver.AddAsync(driver, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return driver.IdDriver;
    }
}