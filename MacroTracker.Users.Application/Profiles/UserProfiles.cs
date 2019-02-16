using AutoMapper;
using MacroTracker.Users.Application.UseCases;
using MacroTracker.Users.Application.UseCases.SearchUsers;
using MacroTracker.Users.Application.UseCases.Users;
using MacroTracker.Users.Domain;

namespace MacroTracker.Users.Application.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<RegisterUserUseCase, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, UserDto>();
        }
    }
}