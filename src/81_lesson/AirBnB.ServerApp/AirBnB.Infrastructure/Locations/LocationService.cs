using AirBnB.Application.Locations;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace AirBnB.Infrastructure.Locations;

public class LocationService(ILocationRepository locationRepository) : ILocationService
{
    public IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = null, bool asNoTracking = false)
    {
        return locationRepository
            .Get(predicate, asNoTracking)
            .OrderBy(location => location.Rating);
    }

    public IQueryable<Location> GetByCategoryId(Guid categoryId, bool asNoTracking = false)
    {
        return locationRepository.Get(location => location.CategoryId == categoryId, asNoTracking);
    }

    public ValueTask<Location?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return locationRepository.GetByIdAsync(id, asNoTracking, cancellationToken);
    }
}