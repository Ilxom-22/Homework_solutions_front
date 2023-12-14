using AirBnB.Domain.Common.Entities;

namespace AirBnB.Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;

    public virtual List<Location> Locations { get; set; }
}