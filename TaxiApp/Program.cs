using TaxiApp.Data;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Modules.DriverModule.Mapping;
using TaxiApp.Modules.DriverModule.Handlers.Create;
using TaxiApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        
        builder.Services.AddDbContext<TaxiAppDataContext>(options =>
        {
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("TaxiAppConnection"),
                opt =>
                {
                    opt.EnableRetryOnFailure();
                });
        });

        builder.Services.AddMediatR(o =>
        {
            o.Lifetime = ServiceLifetime.Scoped;
            o.RegisterServicesFromAssemblies(typeof(CreateDriverCommand).Assembly);
        });

        builder.Services.AddAutoMapper(o =>
        {
            o.AddMaps(typeof(DriverMapProfile).Assembly);
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseMiddleware<ExceptionMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}