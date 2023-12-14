namespace AirBnB.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddMappers()
            .AddValidators()
            .AddLocationsInfrastructure()
            .AddCors()
            .AddExposers()
            .AddDevTools();

        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseCors();
        app.UseExposers().UseDevTools();

        return new(app);
    }
}