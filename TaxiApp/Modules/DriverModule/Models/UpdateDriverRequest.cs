namespace TaxiApp.Modules.DriverModule.Models;

public record UpdateDriverRequest
{
    public int IdDriver { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
}