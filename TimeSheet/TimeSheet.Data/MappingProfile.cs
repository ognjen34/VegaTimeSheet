using AutoMapper;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserEntity>();
        CreateMap<UserEntity, User>();

    }
}
