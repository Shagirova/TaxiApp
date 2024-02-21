using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaxiApp.Data;

public class Driver
{
    public int IdDriver { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public virtual ICollection<DriverCar>? DriverCar { get; set; }

}
public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(s => s.IdDriver);

        builder.Property(s => s.FirstName)
            .HasMaxLength(128);

        builder.Property(s => s.MiddleName)
            .HasMaxLength(128)
            .IsRequired(false);

        builder.Property(s => s.LastName)
            .HasMaxLength(128);

        builder.Property(s => s.BirthDate)
            .IsRequired(false);

        builder.HasIndex(s => new { s.LastName, s.FirstName, s.MiddleName, s.BirthDate })
            .IsUnique(true);
    }
}