using AutoMapper;
using ITry.Application.DomainModels;
using ITry.Data;
using MediatR;

namespace ITry.Features
{
    public record UpdateProgressCommand(IEnumerable<TodoItemModel> Todos) : IRequest;

    public class UpdateProgressHandler : IRequestHandler<UpdateProgressCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IDataStore data;

        public UpdateProgressHandler(IDataStore data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProgressCommand request, CancellationToken cancellationToken)
        {
            var tasks = request.Todos.Select(async x =>
            {
                var todo = await data.GetTodoById(x.Id);
                todo.CurrentWeek.TodoDays = mapper.Map<TodoDay[]>(x.CurrentWeek.TodoDays);
                await data.UpdateTodo(todo);
            });
            await Task.WhenAll(tasks);
            return Unit.Value;
        }
    }
}
