using AirBnB.Domain.Common.Constants;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace AirBnB.Persistence.SeedData.Services;

public static class SeedDataExtensions
{
    public static async ValueTask InitializeSeedDataAsync(this IServiceProvider provider)
    {
        var locationDatabase = provider.GetRequiredService<LocationsDataContext>();

        if (!await locationDatabase.Categories.AnyAsync())
        {
            await locationDatabase.InitializeCategoriesAsync();
        }

        await locationDatabase.InitializeCategoriesAsync();
    }

    private static async ValueTask InitializeCategoriesAsync(this LocationsDataContext dbContext)
    {
        var rawData = File.ReadAllText(FilePathConstants.LocationCategorySeedDataPath);

        var categories = JsonSerializer.Deserialize<List<Category>>(rawData)
            ?? throw new InvalidOperationException("Cannot serialize given object.");

        foreach (var category in categories)
        {
            var id = Guid.NewGuid();
            var filePath = FilePathConstants.LocationCategoryPath
                .Replace(FilePathConstants.FileNameToken, $"{id}{Path.GetExtension(category.ImageUrl)}");

            await HttpClientBroker.DownloadAsync(category.ImageUrl, filePath);

            category.Id = id;
            category.ImageUrl = filePath;

            await dbContext.Categories.AddAsync(category);
        }

       await dbContext.SaveChangesAsync();
    }
}