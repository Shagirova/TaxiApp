﻿namespace TaxiApp.Modules.DriverModule.Models;
public record CreateDriverRequest
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
}