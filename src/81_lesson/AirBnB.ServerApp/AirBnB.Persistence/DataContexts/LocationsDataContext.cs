using AirBnB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Persistence.DataContexts;

public class LocationsDataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Location> Locations => Set<Location>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocationsDataContext).Assembly);
    
}