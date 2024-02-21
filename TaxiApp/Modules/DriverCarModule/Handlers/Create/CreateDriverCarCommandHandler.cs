using AutoMapper;
using MediatR;
using TaxiApp.Data;

namespace TaxiApp.Modules.DriverCarModule.Handlers.Create;

public class CreateDriverCarCommandHandler : IRequestHandler<CreateDriverCarCommand, bool>
{
    private readonly TaxiAppDataContext _dbContext;
    private readonly IMapper _mapper;
    public CreateDriverCarCommandHandler(TaxiAppDataContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateDriverCarCommand command, CancellationToken cancellationToken)
    {
        var driverCar = _mapper.Map<DriverCar>(command.DriverCarRequest);
        await _dbContext.DriverCar.AddAsync(driverCar, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}