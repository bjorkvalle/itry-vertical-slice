using ITry.Application.DomainModels;

namespace ITry.Data
{
    public interface IDataStore
    {
        Task UpdateTodo(Todo todo);
        Task<Todo> GetTodoById(int id);
        Task<IEnumerable<Todo>> GetAllTodos();
    }
}