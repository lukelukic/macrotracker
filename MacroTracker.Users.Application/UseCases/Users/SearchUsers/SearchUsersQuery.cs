using MacroTracker.Users.Application.Queries;
using MacroTracker.Users.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MacroTracker.Users.Application.UseCases.SearchUsers
{
    public class SearchUsersQuery : IRequest<IEnumerable<UserDto>>, IQuery<User>
    {
        public string Keyword { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PerPage { get; set; } = 50;

        public string KeywordLower => Keyword.ToLower();

        public Expression<Func<User, bool>> AsQuery
        {
            get
            {
                if (Keyword == null)
                {
                    return u => u.IsActive;
                }

                return u => 
                    u.IsActive && 
                    (u.FirstName.ToLower().Contains(KeywordLower) || 
                    u.LastName.ToLower().Contains(KeywordLower) || 
                    u.Username.ToLower().Contains(KeywordLower));
            }
        }
    }
}