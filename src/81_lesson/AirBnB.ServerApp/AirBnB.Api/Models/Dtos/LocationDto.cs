namespace AirBnB.Api.Models.Dtos;

public class LocationDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;

    public decimal Price { get; set; }

    public double Rating { get; set; }
}