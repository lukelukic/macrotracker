using EventBus;
using EventBus.Events;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MacroTracker.Users.Application.UseCases.RegisterTrainer
{
    public class RegisterTrainerHandler : IRequestHandler<RegisterTrainerRequest>
    {
        private readonly ITrainerRepository _repo;
        private readonly IEventBus _bus;

        public RegisterTrainerHandler(IEventBus bus, ITrainerRepository repo)
        {
            _bus = bus;
            _repo = repo;
        }

        public async Task<Unit> Handle(RegisterTrainerRequest request, CancellationToken cancellationToken)
        {
            if (_repo.Get(u => u.Email == request.Email).Any())
                throw new EntityAlreadyExists($"{request.Email} is already in use.");

            if (_repo.Get(u => u.Username == request.Username).Any())
                throw new EntityAlreadyExists($"{request.Username} is already in use.");

            var user = _repo.Add(new Trainer
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
            return Unit.Value;
        }
    }
}