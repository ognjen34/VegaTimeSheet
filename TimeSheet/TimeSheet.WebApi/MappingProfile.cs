using AutoMapper;
using TimeSheet.WebApi.DTOs.Requests;
using TimeSheet.WebApi.DTOs.Responses;
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
        CreateMap<CreateCategoryReq, Category>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CreateCountryReq, Country>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CreateClientReq, Client>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CreateWorkHourReq, WorkHour>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CreateProjectReq, Project>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

        CreateMap<User, UserRes>();
        CreateMap<Category, CategoryRes>();
        CreateMap<Country, CountryRes>();
        CreateMap<Client, ClientRes>();
        CreateMap<WorkHour, WorkHourRes>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<Project, ProjectRes>()
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Client.Id))
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name))
            .ForMember(dest => dest.LeadId, opt => opt.MapFrom(src => src.Lead.Id))
            .ForMember(dest => dest.LeadName, opt => opt.MapFrom(src => src.Lead.Name));


        CreateMap<UpdateUserReq, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));

        CreateMap<WorkHour, ReportInstance>()
           .ForMember(dest => dest.TeamMember, opt => opt.MapFrom(src => src.User.Name))
           .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
           .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time + src.OverTime))
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));



    }
}
