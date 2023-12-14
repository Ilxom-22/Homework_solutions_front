using Microsoft.EntityFrameworkCore;

namespace AirBnB.Persistence.DataContexts;

public class LocationsDataContext(DbContextOptions options) : DbContext(options)
{
    
}