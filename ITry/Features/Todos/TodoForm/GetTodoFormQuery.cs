using AutoMapper;
using ITry.Data;
using MediatR;

namespace ITry.Features
{
    public record GetTodoFormQuery(int Id) : IRequest<TodoFormModel>;

    public class GetTodoFormHandler : IRequestHandler<GetTodoFormQuery, TodoFormModel>
    {
        private readonly IMapper mapper;
        private readonly IDataStore data;

        public GetTodoFormHandler(IDataStore data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<TodoFormModel> Handle(GetTodoFormQuery request, CancellationToken cancellationToken)
        {
            var todo = await data.GetTodoById(request.Id);
            var model = mapper.Map<TodoFormModel>(todo);
            return model;
        }
    }
}
