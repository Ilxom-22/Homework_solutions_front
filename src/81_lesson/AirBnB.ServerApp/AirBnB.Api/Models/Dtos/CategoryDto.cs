namespace AirBnB.Api.Models.Dtos;

public class CategoryDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;
}