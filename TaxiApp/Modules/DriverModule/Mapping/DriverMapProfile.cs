using AutoMapper;
using TaxiApp.Data;
using TaxiApp.Modules.DriverModule.Models;

namespace TaxiApp.Modules.DriverModule.Mapping;

public class DriverMapProfile : Profile
{
    public DriverMapProfile() 
    {
        CreateMap<CreateDriverRequest, Driver>();
        CreateMap<UpdateDriverRequest, Driver>();
    }
}
