using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthKernel.Todos.Data.Models;

namespace WealthKernel.Todos.Data;

public class InMemoryTodosRepository : ITodosRepository
{
    private readonly ConcurrentDictionary<string,Todo> _todos = new();

    public Task<Todo> GetTodo(string id)
    {
        return Task.FromResult(_todos.GetValueOrDefault(id));
    }

    public Task<IList<Todo>> GetTodos(string label = null, bool? isComplete = null)
    {
        var todos= _todos.Values.AsEnumerable();

        if (!string.IsNullOrEmpty(label)) todos = todos.Where(t => t.Label == label);
        if (isComplete.HasValue) todos = todos.Where(t => t.IsComplete == isComplete.Value);

        return Task.FromResult<IList<Todo>>(todos.ToArray());
    }

    public Task AddTodo(Todo todo)
    {
        var added = _todos.TryAdd(todo.Id, todo);

        if (!added)
        {
            throw new InvalidOperationException("Todo could not be added.");
        }

        return Task.CompletedTask;
    }
}
