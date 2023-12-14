using AirBnB.Domain.Entities;
using System.Linq.Expressions;

namespace AirBnB.Application.Locations;

public interface ICategoryService
{
    IQueryable<Category> Get(Expression<Func<Category, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Category?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);
}