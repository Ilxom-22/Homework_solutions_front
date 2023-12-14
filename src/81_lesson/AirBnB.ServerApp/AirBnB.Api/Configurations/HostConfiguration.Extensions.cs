using AirBnB.Application.Locations;
using AirBnB.Infrastructure.Locations;
using AirBnB.Persistence.DataContexts;
using AirBnB.Persistence.Repositories;
using AirBnB.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AirBnB.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => { options.AddDefaultPolicy(policyBuilder =>
            { 
                policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }); 
        });

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static WebApplicationBuilder AddLocationsInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<LocationsDataContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("AppDatabaseConnection")));

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ILocationRepository, LocationRepository>();

        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ILocationService, LocationService>();

        return builder;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}