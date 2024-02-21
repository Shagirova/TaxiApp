using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TaxiApp.Data;

public class DriverCar
{
    public int IdDriver { get; set; }
    public int IdCar { get; set; }
    public required Driver Driver { get; set; }
    public required Car Car { get; set; }
}
public class DriverCarConfiguration : IEntityTypeConfiguration<DriverCar>
{
    public void Configure(EntityTypeBuilder<DriverCar> builder)
    {
        builder.HasKey(s => new { s.IdDriver, s.IdCar });

        builder.HasOne(d => d.Car)
                    .WithMany(p => p.DriverCar)
                    .HasForeignKey(d => d.IdCar)
                    .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Driver)
                    .WithMany(p => p.DriverCar)
                    .HasForeignKey(d => d.IdDriver)
                    .OnDelete(DeleteBehavior.Cascade);
    }
}