using EventBus;
using EventBus.Events;
using MacroTracker.Users.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MacroTracker.Users.Application.UseCases.Trainers.DeactivateTrainer
{
    public class DeactivateTrainerHandler : IRequestHandler<DeactivateTrainerRequest>
    {
        private readonly IEventBus _bus;
        private readonly ITrainerRepository _repo;

        public DeactivateTrainerHandler(IEventBus bus, ITrainerRepository repo)
        {
            _bus = bus;
            _repo = repo;
        }

        public Task<Unit> Handle(DeactivateTrainerRequest request, CancellationToken cancellationToken)
        {
            var trainer = _repo.Get(request.TrainerId);
            if (!trainer.IsActive)
                throw new UserAlreadyInactiveException($"User {trainer.Username} is already inactive.");

            trainer.IsActive = false;
            _repo.Update(trainer);

            _bus.Publish(new UserDeactivatedEvent
            {
                Email = trainer.Email,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName
            });

            return Unit.Task;
        }
    }
}