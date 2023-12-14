namespace AirBnB.Api.Models.Dtos;

public class LocationDto
{
    public string Name { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;

    public int BuiltYear { get; set; }

    public decimal PricePerNight { get; set; }

    public double Rating { get; set; }
}