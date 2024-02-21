using AutoMapper;
using MediatR;
using TaxiApp.Data;

namespace TaxiApp.Modules.DriverModule.Handlers.Update
{
    public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, bool>
    {
        private readonly TaxiAppDataContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateDriverCommandHandler(TaxiAppDataContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDriverCommand command, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver>(command.Driver);
            _dbContext.Driver.Update(driver);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}