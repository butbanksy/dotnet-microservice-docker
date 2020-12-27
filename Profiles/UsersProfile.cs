using AutoMapper;
using UsersMicroservice.DTO;
using UsersMicroservice.Models;

namespace UsersMicroservice.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserLoginSuccessfulDto>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserRegisterSuccessfulDto>();
            CreateMap<User, UserTokenDto>();
            
        }

    }
}