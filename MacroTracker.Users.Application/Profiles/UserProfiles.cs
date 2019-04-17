using AutoMapper;
using MacroTracker.Users.Application.UseCases;
using MacroTracker.Users.Application.UseCases.SearchUsers;
using MacroTracker.Users.Application.UseCases.Users;
using MacroTracker.Users.Domain;
using System.Diagnostics.CodeAnalysis;

namespace MacroTracker.Users.Application.Profiles
{
    [ExcludeFromCodeCoverage]
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