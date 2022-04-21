using AutoMapper;
using ITry.Data;
using MediatR;

namespace ITry.Features
{
    public record GetTodoItemsQuery() : IRequest<IEnumerable<TodoItemModel>>;

    public class GetTodoItemsHandler : IRequestHandler<GetTodoItemsQuery, IEnumerable<TodoItemModel>>
    {
        private readonly IMapper mapper;
        private readonly IDataStore data;

        public GetTodoItemsHandler(IDataStore data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TodoItemModel>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var forecasts = await data.GetAllTodos();
            var items = mapper.Map<List<TodoItemModel>>(forecasts);
            return items;
        }
    }
}
