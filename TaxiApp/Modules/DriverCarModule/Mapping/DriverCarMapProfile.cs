using AutoMapper;
using TaxiApp.Data;
using TaxiApp.Modules.DriverCarModule.Models;

namespace TaxiApp.Modules.DriverCarModule.Mapping;

public class DriverCarMapProfile : Profile
{
    public DriverCarMapProfile()
    {
        CreateMap<CreateDriverCarRequest, DriverCar>();
    }
}
