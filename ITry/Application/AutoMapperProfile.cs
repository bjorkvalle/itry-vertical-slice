using AutoMapper;
using ITry.Application.DomainModels;
using ITry.Application.Dtos;
using ITry.Features;

namespace ITry.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Todo, TodoDto>();
            CreateMap<Todo, TodoItemModel>();
            CreateMap<TodoWeek, TodoWeekModel>();
            CreateMap<TodoDay, TodoDayModel>().ReverseMap();
            //CreateMap<User, UserResource>().ReverseMap();

            //CreateMap<UploadLog, UploadLogResource>()
            //    .ForMember(dest => dest.RevisionAction, opts => opts.MapFrom(src => Enum.GetNames(typeof(RevisionActions))[src.RevisionAction]))
            //    .ReverseMap()
            //    ;
        }
    }
}
