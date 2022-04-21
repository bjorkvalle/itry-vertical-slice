//using ITry.Application.DomainModels;
//using ITry.Data;
//using MediatR;
//using Microsoft.AspNetCore.Components;

//namespace ITry.Pages
//{
//    public partial class Index : ComponentBase
//    {
//        [Inject] public IMediator Mediator { get; set; }

//        private string[] list = new string[] { "M", "T", "W", "T", "F", "S", "S" };

//        private IEnumerable<Todo> todos;

//        //public class Todo
//        //{
//        //    public int Id { get; set; }
//        //    public string Name { get; set; }
//        //}

//        protected override async Task OnInitializedAsync()
//        {
//            todos = await Mediator.Send(new GetProductsQuery());



//            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(todos));
//        }

//        protected async Task Create()
//        {
//            await Mediator.Send(new AddProductCommand(new Todo { Id = 616, Title = "Satan" }));

//            todos = await Mediator.Send(new GetProductsQuery());



//            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(todos));
//        }

//        public record GetProductsQuery() : IRequest<IEnumerable<Todo>>;

//        public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Todo>>
//        {
//            private readonly FakeDataStore _fakeDataStore;

//            public GetProductsHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

//            public async Task<IEnumerable<Todo>> Handle(GetProductsQuery request,
//                CancellationToken cancellationToken) => (IEnumerable<Todo>)(await _fakeDataStore.GetAllProducts());
//        }

//        public record AddProductCommand(Todo Product) : IRequest;

//        public class AddProductHandler : IRequestHandler<AddProductCommand, Unit>
//        {
//            private readonly FakeDataStore _fakeDataStore;

//            public AddProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

//            public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
//            {
//                var entity = new Todo { Id=request.Product.Id, Title=request.Product.Title };
//                await _fakeDataStore.AddProduct(entity);

//                return Unit.Value;
//            }
//        }
//    }
//}
