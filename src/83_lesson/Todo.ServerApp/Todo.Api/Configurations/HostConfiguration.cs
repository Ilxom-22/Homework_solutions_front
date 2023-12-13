namespace ToDo.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddDbContext()
            .AddMappers()
            .AddValidators()
            .AddTodosServices()
            .AddCors()
            .AddExposers()
            .AddDevTools();

        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseCors();
        app.UseExposers();

        return new(app);
    }
}