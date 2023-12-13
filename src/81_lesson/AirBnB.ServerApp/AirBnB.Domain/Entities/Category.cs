using AirBnB.Domain.Common.Entities;

namespace AirBnB.Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; }

    public string ImageUrl { get; set; }
}