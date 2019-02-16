using MediatR;
using System.Collections.Generic;

namespace MacroTracker.Users.Application.UseCases.SearchUsers
{
    public class SearchUsersRequest : IRequest<IEnumerable<UserDto>>
    {
        public string Keyword { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PerPage { get; set; } = 50;
    }
}