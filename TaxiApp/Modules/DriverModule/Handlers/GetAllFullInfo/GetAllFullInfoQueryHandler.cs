using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Data;
using TaxiApp.Modules.DriverModule.Handlers.GetAllFullInfo;
using TaxiApp.Modules.DriverModule.Models;

namespace TaxiApp.Modules.DriverModule.Handlers.GetAll;

public class GetAllFullInfoQueryHandler : IRequestHandler<GetAllFullInfoQuery, IReadOnlyCollection<GetDriverFullInfoResponse>>
{
    private readonly TaxiAppDataContext _dbContext;
    public GetAllFullInfoQueryHandler(TaxiAppDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<GetDriverFullInfoResponse>> Handle(GetAllFullInfoQuery query, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Driver.Select(driver => new GetDriverFullInfoResponse
        {
            FullName = string.Join(" ", driver.FirstName, driver.MiddleName, driver.LastName),
            Age = CalculateAge(driver.BirthDate),
            Cars = driver.DriverCar.Select(driverCar => new GetDriverFullInfoResponse.CarInfo
            {
                BrandModel = $"{driverCar.Car.Brand} ({driverCar.Car.Model})",
                Number = driverCar.Car.Number
            }).ToArray()
        }).ToArrayAsync(cancellationToken);

        return result;
    }

    static int? CalculateAge(DateTime? birthDate)
    {
        if (birthDate == null)
        {
            return null;
        }

        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.GetValueOrDefault().Year;

        if (age > 0 && birthDate > today.AddYears(-age))
        {
            age--;
        }        
        
        return age;
    }
}
