﻿using System.Linq.Expressions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Todos.Services;
using Todo.Domain.Entities;
using Todo.Domain.Enums;
using Todo.Persistence.Repositories.Interfaces;

namespace Todo.Infrastructure.Todos.Services;

public class TodoService(ITodoRepository todoRepository, IValidator<TodoItem> todoValidator) : ITodoService
{
    public IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>>? predicate = default, bool asNoTracking = false)
    {
        return todoRepository.Get(predicate, asNoTracking);
    }

    /// <summary>
    /// Gets Todos in this order:
    /// 1. Active Todos
    /// 2. Completed Todos
    /// 3. Overdue Todos
    /// </summary>
    /// <param name="asNoTracking"></param>
    /// <returns></returns>
    public async ValueTask<IList<TodoItem>> GetAsync(bool asNoTracking = false)
    {
        var todos = await todoRepository.Get().ToListAsync();
        return todos
            .Where(todo => !todo.IsDone && todo.DueTime > DateTime.Now).OrderBy(todo => todo.DueTime) 
            .Concat(todos.Where(todo => todo.IsDone).OrderByDescending(todo => todo.ModifiedTime))
            .Concat(todos.Where(todo => !todo.IsDone && todo.DueTime <= DateTime.Now).OrderByDescending(todo => todo.DueTime)) 
            .ToList();
    }

    public ValueTask<TodoItem?> GetByIdAsync(Guid todoId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return todoRepository.GetByIdAsync(todoId, asNoTracking, cancellationToken);
    }

    public ValueTask<TodoItem> CreateAsync(TodoItem todoItem, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = todoValidator.Validate(todoItem, options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()));
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        todoItem.CreatedTime = DateTimeOffset.UtcNow;

        return todoRepository.CreateAsync(todoItem, saveChanges, cancellationToken);
    }

    public ValueTask<bool> UpdateAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
    {
        var validationResult = todoValidator.Validate(todoItem, options => options.IncludeRuleSets(EntityEvent.OnUpdate.ToString()));
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return todoRepository.UpdateAsync(todoItem, cancellationToken);
    }

    public ValueTask<bool> DeleteByIdAsync(Guid todoId, CancellationToken cancellationToken = default)
    {
        return todoRepository.DeleteByIdAsync(todoId, cancellationToken);
    }
}