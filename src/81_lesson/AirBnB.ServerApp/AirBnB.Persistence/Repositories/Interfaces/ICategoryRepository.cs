using AirBnB.Domain.Entities;
using System.Linq.Expressions;

namespace AirBnB.Persistence.Repositories.Interfaces;

public interface ICategoryRepository
{
    IQueryable<Category> Get(Expression<Func<Category, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Category?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);
}