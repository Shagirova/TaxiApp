using Microsoft.EntityFrameworkCore;

namespace TaxiApp.Data;
public class TaxiAppDataContext : DbContext
{
    public TaxiAppDataContext(DbContextOptions<TaxiAppDataContext> options) : base(options)
    {

    }
    public virtual DbSet<Driver> Driver { get; set; }
    public virtual DbSet<Car> Car { get; set; }
    public virtual DbSet<DriverCar> DriverCar { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new DriverConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new DriverCarConfiguration());
    }
}