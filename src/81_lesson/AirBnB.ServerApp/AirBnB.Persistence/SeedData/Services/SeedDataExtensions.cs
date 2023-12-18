using AirBnB.Domain.Common.Constants;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.DataContexts;
using AirBnB.Persistence.SeedData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace AirBnB.Persistence.SeedData.Services;

public static class SeedDataExtensions
{
    public static async ValueTask InitializeSeedDataAsync(this IServiceProvider provider)
    {
        var locationDatabase = provider.GetRequiredService<LocationsDataContext>();

        // Initializing Location Categories.
        if (!await locationDatabase.Categories.AnyAsync())
            await locationDatabase.InitializeCategoriesAsync();

        // Initializing Locations.
        if (!await locationDatabase.Locations.AnyAsync())
            await locationDatabase.InitializeLocationsAsync();
    }

    private static async ValueTask InitializeCategoriesAsync(this LocationsDataContext dbContext)
    {
        var rawData = File.ReadAllText(FilePathConstants.LocationCategorySeedDataPath);

        var categories = JsonSerializer.Deserialize<List<Category>>(rawData)
            ?? throw new InvalidOperationException("Cannot serialize given location categories.");

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

    private static async ValueTask InitializeLocationsAsync(this LocationsDataContext dbContext)
    {
        var rawData = File.ReadAllText(FilePathConstants.LocationSeedDataPath);
        var locationDtos = JsonSerializer.Deserialize<List<LocationSeedDto>>(rawData) ?? throw new InvalidOperationException("Cannot serialize give locations.");

        var categoryName = string.Empty;
        var initialCategoryId = Guid.Empty;

        foreach (var locationDto in locationDtos)
        {
            var id = Guid.NewGuid();
            var filePath = FilePathConstants.LocationPath
                .Replace(FilePathConstants.FileNameToken, $"{id}.jpg");

            await HttpClientBroker.DownloadAsync(locationDto.ImageUrl, filePath);

            var categoryId = Guid.Empty;

            if (locationDto.Category == categoryName)
            {
                categoryId = initialCategoryId;
            }
            else
            {
                categoryId = (dbContext.Categories.FirstOrDefault(category => category.Name == locationDto.Category)?.Id)
                ?? throw new ArgumentException("Category not found!");

                categoryName = locationDto.Category;
                initialCategoryId = categoryId;
            }

            var location = new Location
            {
                Id = id,
                Name = locationDto.Name,
                ImageUrl = filePath,
                PricePerNight = locationDto.Price / 5,
                Rating = locationDto.Rating,
                CategoryId = categoryId
            };

            await dbContext.Locations.AddAsync(location);
        }

        await dbContext.SaveChangesAsync();
    }
}