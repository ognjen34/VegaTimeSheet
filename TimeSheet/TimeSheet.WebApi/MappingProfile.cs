using AutoMapper;
using TimeSheet.Application.DTOs.Requests;
using TimeSheet.Application.DTOs.Responses;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserEntity>();
        CreateMap<UserEntity, User>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));

        CreateMap<Category, CategoryEntity>();
        CreateMap<CategoryEntity, Category>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));

        CreateMap<Project, ProjectEntity>();
        CreateMap<ProjectEntity, Project>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));

        CreateMap<Client, ClientEntity>();
        CreateMap<ClientEntity, Client>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));

        CreateMap<WorkHour, WorkHourEntity>();
        CreateMap<WorkHourEntity, WorkHour>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));

        CreateMap<Country, CountryEntity>();
        CreateMap<CountryEntity, Country>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));

        CreateMap<CreateUserReq, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CreateCountryReq, Country>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CreateClientReq, Client>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

        CreateMap<User, UserRes>();
        CreateMap<Country, CountryRes>();
        CreateMap<Client, ClientRes>();


        CreateMap<UpdateUserReq, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));



    }
}
