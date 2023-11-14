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

        CreateMap<CreateUserRequest, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CreateCategoryRequest, Category>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CreateCountryRequest, Country>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CreateClientRequest, Client>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CreateWorkHourRequest, WorkHour>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CreateProjectRequest, Project>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

        CreateMap<Report, ReportResponse>();
        CreateMap<ReportResponse, Report>();

        CreateMap<ReportInstanceDTO, ReportInstance>();
        CreateMap<ReportInstance, ReportInstanceDTO>();
        CreateMap<PaginationFilterRequest, PaginationFilter>();
        CreateMap<PaginationRequest, Pagination>();
        CreateMap<PaginationReturnObject<Project>, PaginationResponse<ProjectResponse>>();
        CreateMap<PaginationReturnObject<Client>, PaginationResponse<ClientResponse>>();
        CreateMap<PaginationReturnObject<Category>, PaginationResponse<CategoryResponse>>();
        CreateMap<PaginationReturnObject<User>, PaginationResponse<UserResponse>>();






        CreateMap<User, UserResponse>();
        CreateMap<Category, CategoryResponse>();
        CreateMap<Country, CountryResponse>();
        CreateMap<Client, ClientResponse>();
        CreateMap<WorkHour, WorkHourResponse>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<Project, ProjectResponse>()
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Client.Id))
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name))
            .ForMember(dest => dest.LeadId, opt => opt.MapFrom(src => src.Lead.Id))
            .ForMember(dest => dest.LeadName, opt => opt.MapFrom(src => src.Lead.Name));


        CreateMap<UpdateUserRequest, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));
        CreateMap<UpdateProjectRequest, Project>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));
        CreateMap<UpdateClientRequest, Client>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));
        CreateMap<UpdateWorkHourRequest, WorkHour>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));
        CreateMap<Project, WorkDayProjectReponse>();

        CreateMap<WorkHour, ReportInstance>()
           .ForMember(dest => dest.TeamMember, opt => opt.MapFrom(src => src.User.Name))
           .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
           .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time + src.OverTime))
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<WorkHour, WorkDayResponse>()
           .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Project.Client.Name))
           .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Project.Client.Id))
           .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));


        CreateMap<CreateReport, CreateReportRequestDTO>();
        CreateMap<CreateReportRequestDTO, CreateReport>();





    }
}
