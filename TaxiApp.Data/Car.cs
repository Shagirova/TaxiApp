using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaxiApp.Data;
public class Car
{
    public int IdCar { get; set; }
    public string Brand { get; set; } = null!;
    public required string Model { get; set; }
    public required string Number { get; set; }
    public virtual ICollection<DriverCar>? DriverCar { get; set; }
}

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(s => s.IdCar);

        builder.Property(s => s.Brand)
            .HasMaxLength(128);

        builder.Property(s => s.Model)
            .HasMaxLength(128);

        builder.Property(s => s.Number)
            .HasMaxLength(10);

        builder.HasAlternateKey(s => s.Number);
    }
}