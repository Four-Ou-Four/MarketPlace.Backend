using AutoMapper;
using MarketPlace.Application.Identity.Models;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Identity.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<SignInDetails, User>().ReverseMap();
        CreateMap<SignUpDetails, User>().ReverseMap();
    }
}
