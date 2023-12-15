using AirBnB.Domain.Entities;
using AirBnB.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AirBnB.Persistence.SeedData;

public static class SeedDataExtensions
{
    public static async ValueTask InitializeSeedDataAsync(this IServiceProvider provider)
    {
        var locationDatabase = provider.GetRequiredService<LocationsDataContext>();

        if (!await locationDatabase.Categories.AnyAsync())
        {
            await InitializeCategoriesAsync(locationDatabase);
        }
    }

    private static async ValueTask InitializeCategoriesAsync(this LocationsDataContext dbContext)
    {
        var categoryNames = new List<string>()
        {
            "Amazing views", "Castles", "Caves", "Cycladic homes", "New", "OMG!"
        };

        var list = new List<Category>();

        foreach (var categoryName in categoryNames)
        {
            list.Add(new Category { Id = Guid.NewGuid(), Name = categoryName, ImageUrl = $"Categories/{categoryName}.jpg" });
        }

        await dbContext.Categories.AddRangeAsync(list);
        await dbContext.SaveChangesAsync();
    }
}