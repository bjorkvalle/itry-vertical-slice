using ITry.Application.DomainModels;
using ITry.Application.Enums;

namespace ITry.Data
{
    public class FakeDataStore : IDataStore
    {
        private static List<Todo> _todos;
        public FakeDataStore()
        {
            _todos = new List<Todo>
            {
                new Todo { Id = 1, Title = "Läs minst 2 sidor varje dag", IsActive=true, Target=7, CurrentWeek=new TodoWeek{ WeekNumber=22, TodoDays=Enum.GetValues<WeekDays>().Select(day => new TodoDay() { Day = day }).ToArray() } },
                new Todo { Id = 2, Title = "Meditera 2 ggr i veckan", IsActive=true, Target=2, CurrentWeek=new TodoWeek{ WeekNumber=22, TodoDays=Enum.GetValues<WeekDays>().Select(day => new TodoDay() { Day = day }).ToArray() } },
                new Todo { Id = 3, Title = "Nytt recept av undertian varje dag", Target=7, CurrentWeek=new TodoWeek{ WeekNumber=21, TodoDays=Enum.GetValues<WeekDays>().Select(day => new TodoDay() { Day = day }).ToArray() } }
            };
        }
        public async Task AddProduct(Todo product)
        {
            _todos.Add(product);
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<Todo>> GetAllProducts() => await Task.FromResult(_todos);
        public async Task<IEnumerable<Todo>> GetAllTodos() => await Task.FromResult(_todos);

        public async Task<Todo> GetTodoById(int id)
        {
            var todo = _todos.Find(x => x.Id == id);
            return await Task.FromResult(todo);
        }

        public async Task UpdateTodo(Todo todo)
        {
            var update = await GetTodoById(todo.Id);
            update = todo;
            await Task.Delay(500);
        }
    }
}
