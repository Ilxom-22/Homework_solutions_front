namespace AirBnB.Persistence.SeedData.Models;

public class LocationSeedDto
{
    public string Name { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;

    public decimal Price { get; set; }

    public double Rating { get; set; }

    public string Category { get; set; } = default!;
}