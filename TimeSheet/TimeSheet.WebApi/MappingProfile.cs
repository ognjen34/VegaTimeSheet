using AutoMapper;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserEntity>();
        CreateMap<UserEntity, User>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));



    }
}
