using AirBnB.Domain.Entities;
using System.Linq.Expressions;

namespace AirBnB.Application.Locations;

public interface ILocationService
{
    IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Location?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    IQueryable<Location> GetByCategoryId(Guid categoryId, bool asNoTracking = false);
}