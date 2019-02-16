using System;

namespace MacroTracker.Users.Application.UseCases.SearchUsers
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
    }
}