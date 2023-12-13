using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Persistence.DataContexts;
using Todo.Persistence.Repositories.Interfaces;

namespace Todo.Persistence.Repositories;

public class TodoRepository(AppDbContext dbContext) : EntityRepositoryBase<TodoItem, AppDbContext>(dbContext), ITodoRepository
{
    public new IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public new ValueTask<TodoItem?> GetByIdAsync(Guid todoId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(todoId, asNoTracking, cancellationToken);
    }

    public new ValueTask<TodoItem> CreateAsync(TodoItem todoItem, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(todoItem, saveChanges, cancellationToken);
    }

    /// <summary>
    /// Batch Update
    /// </summary>
    /// <param name="todoItem"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> UpdateAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
    {
        var result = await DbContext.Todos
            .Where(x => x.Id == todoItem.Id)
            .ExecuteUpdateAsync(propertySetter => propertySetter
                .SetProperty(todo => todo.Title, todoItem.Title)
                .SetProperty(todo => todo.IsDone, todoItem.IsDone)
                .SetProperty(todo => todo.IsFavorite, todoItem.IsFavorite)
                .SetProperty(todo => todo.DueTime, todoItem.DueTime)
                .SetProperty(todo => todo.ReminderTime, todoItem.ReminderTime)
                .SetProperty(todo => todo.ModifiedTime, DateTimeOffset.UtcNow),
            cancellationToken
        );
        
        return result > 0;
    }

    /// <summary>
    /// Batch Delete
    /// </summary>
    /// <param name="todoId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> DeleteByIdAsync(Guid todoId, CancellationToken cancellationToken = default)
    {
        var result = await DbContext.Todos
            .Where(x => x.Id == todoId)
            .ExecuteDeleteAsync(cancellationToken);
        
        return result > 0;
    }
}