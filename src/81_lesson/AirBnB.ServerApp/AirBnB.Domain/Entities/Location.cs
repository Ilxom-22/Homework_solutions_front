using AirBnB.Domain.Common.Entities;

namespace AirBnB.Domain.Entities;

public class Location : Entity
{
    public string Name { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;

    public decimal PricePerNight { get; set; }

    public double Rating { get; set; }

    public Guid CategoryId { get; set; }  

    public virtual Category Category { get; set; }
}