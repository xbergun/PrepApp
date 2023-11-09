using AutoMapper;
using NTT.Core.DTOs;
using NTT.Core.Entity;

namespace NTT.Service.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<UserRole, UserRoleDto>().ReverseMap();
        CreateMap<TelephoneNumber, TelephoneNumberDto>().ReverseMap();
        CreateMap<UserWithUserRoleDto, User>().ReverseMap();
        CreateMap<UserWithTelephoneNumbersDto, User>().ReverseMap().ForMember(dest => dest.TelephoneNumberDtos,
            opt => opt.MapFrom(src => src.TelephoneNumbers));
    }
}