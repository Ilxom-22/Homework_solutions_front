using AirBnB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnB.Persistence.EntityConfigurations;

public class LocationConfigurations : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(location => location.Id);

        builder.Property(location => location.Name).IsRequired().HasMaxLength(30);
        builder.Property(location => location.ImageUrl).IsRequired();
        builder.Property(location => location.CategoryId).IsRequired();
        builder.Property(location => location.PricePerNight).IsRequired();

        builder
            .HasOne(location => location.Category)
            .WithMany(category => category.Locations);
    }
}