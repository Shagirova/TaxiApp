namespace TaxiApp.Modules.DriverCarModule.Models;

public record CreateDriverCarRequest
{
    public int IdDriver { get; set; }
    public int IdCar { get; set; }
}
