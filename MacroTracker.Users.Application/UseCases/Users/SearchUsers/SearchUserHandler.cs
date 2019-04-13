using MacroTracker.Users.Application.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MacroTracker.Users.Application.UseCases.SearchUsers
{
    public class SearchUserHandler : IRequestHandler<SearchUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _repo;

        public SearchUserHandler(IUserRepository repo) => _repo = repo;

        public Task<IEnumerable<UserDto>> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
        {
            var result = _repo.Get(request.AsQuery, request.PerPage, request.PageNumber);

            return Task.FromResult(result.Select(u => new UserDto
            {
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Id = u.Id
            }));
        }
    }
}