using AirBnB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnB.Persistence.EntityConfigurations;

public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(category => category.Name).IsRequired().HasMaxLength(64);
        builder.Property(category => category.ImageUrl).IsRequired();

        builder
            .HasMany(category => category.Locations)
            .WithOne(location => location.Category)
            .HasForeignKey(location => location.CategoryId)
            .HasPrincipalKey(category => category.Id);
    }
}