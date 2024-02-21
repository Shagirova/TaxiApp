namespace TaxiApp.Modules.DriverCarModule.Models
{
    public record DeleteDriverCarRequest
    {
        public int IdDriver { get; set; }
        public int IdCar { get; set; }
    }
}