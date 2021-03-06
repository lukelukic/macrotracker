﻿using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MacroTracker.Users.Application.UseCases.Users.UpdateUserUseCase
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest>
    {
        private readonly IUserRepository _repo;

        public UpdateUserHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public Task<Unit> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _repo.Get(request.UserId);

            if (user == null)
                throw new EntityNotFoundException(request.UserId, "User");

            if (!user.IsActive)
                throw new EntityInactiveException($"User with an id of {request.UserId} is inactive.");

            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Username = request.Username;

            _repo.Update(user);

            return Unit.Task;
        }
    }
}