using System.Collections.Generic;
using System.Threading.Tasks;
using WealthKernel.Todos.Data.Models;

namespace WealthKernel.Todos.Data;

public interface ITodosRepository
{
    public Task<Todo> GetTodo(string id);

    public Task<IList<Todo>> GetTodos(string label = null, bool? isComplete = null);

    public Task AddTodo(Todo todo);
}
