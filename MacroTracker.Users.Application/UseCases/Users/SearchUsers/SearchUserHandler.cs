using MacroTracker.Users.Application.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MacroTracker.Users.Application.UseCases.SearchUsers
{
    public class SearchUserHandler : IRequestHandler<SearchUsersRequest, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _repo;

        public SearchUserHandler(IUserRepository repo) => _repo = repo;

        public Task<IEnumerable<UserDto>> Handle(SearchUsersRequest request, CancellationToken cancellationToken)
        {
            var result = request.Keyword == null
                ? _repo.Get(u => u.IsActive, request.PerPage, request.PageNumber)
                : _repo.Get(
                    u => u.IsActive &&
                        (u.FirstName.ToLower().Contains(request.Keyword.ToLower()) ||
                         u.LastName.ToLower().Contains(request.Keyword.ToLower())),
                    request.PerPage,
                    request.PageNumber);

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