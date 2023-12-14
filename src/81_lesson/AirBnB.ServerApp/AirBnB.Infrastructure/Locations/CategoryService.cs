using AirBnB.Application.Locations;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace AirBnB.Infrastructure.Locations;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public IQueryable<Category> Get(Expression<Func<Category, bool>>? predicate = null, bool asNoTracking = false)
    {
        return categoryRepository
            .Get(predicate, asNoTracking)
            .OrderBy(category => category.Name);
    }

    public ValueTask<Category?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return categoryRepository.GetByIdAsync(id, asNoTracking, cancellationToken);
    }
}