using AirBnB.Domain.Entities;
using AirBnB.Persistence.DataContexts;
using AirBnB.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace AirBnB.Persistence.Repositories;

public class CategoryRepository(LocationsDataContext dbContext) : EntityRepositoryBase<LocationsDataContext, Category>(dbContext), ICategoryRepository
{
    public new IQueryable<Category> Get(Expression<Func<Category, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public new async ValueTask<Category?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }
}