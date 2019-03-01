using EventBus;
using EventBus.Events;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MacroTracker.Users.Application.UseCases
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserUseCase>
    {
        private readonly IUserRepository _repo;
        private readonly IEventBus _bus;

        public RegisterUserHandler(IEventBus bus, IUserRepository repo)
        {
            _bus = bus;
            _repo = repo;
        }

        public Task<Unit> Handle(RegisterUserUseCase request, CancellationToken cancellationToken)
        {
            if (_repo.Get(u => u.Email.ToLower() == request.Email.ToLower()).Any())
                throw new EntityAlreadyExistsException($"{request.Email} is already in use.");

            if (_repo.Get(u => u.Username.ToLower() == request.Username.ToLower()).Any())
                throw new EntityAlreadyExistsException($"{request.Username} is already in use.");

            _repo.Add(new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
            });

            _bus.Publish(new UserRegisteredEvent()
            {
                DateRegistered = DateTime.Now,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username
            });

            return Unit.Task;
        }
    }
}