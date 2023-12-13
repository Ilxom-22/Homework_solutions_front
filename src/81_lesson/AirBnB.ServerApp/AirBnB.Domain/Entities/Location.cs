using AirBnB.Domain.Common.Entities;

namespace AirBnB.Domain.Entities;

public class Location : Entity
{
    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public string CategoryId { get; set; }

    public int BuiltYear { get; set; }

    public decimal PricePerNight { get; set; }

    public double Rating { get; set; }
}