using EventBus;
using EventBus.Events;
using MacroTracker.Users.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MacroTracker.Users.Application.UseCases.Trainers.AcceptTrainingRequest
{
    public class AcceptTrainingRequestHandler : IRequestHandler<AcceptTrainingRequest>
    {
        private readonly IEventBus _bus;
        private readonly ITrainerRepository _trainerRepo;
        private readonly ITrainingRequestRepository _requestRepo;

        public AcceptTrainingRequestHandler(IEventBus bus, ITrainerRepository trainerRepo, ITrainingRequestRepository requestRepo)
        {
            _bus = bus;
            _trainerRepo = trainerRepo;
            _requestRepo = requestRepo;
        }

        public Task<Unit> Handle(AcceptTrainingRequest request, CancellationToken cancellationToken)
        {
            _trainerRepo.AcceptTrainingRequest(request.RequestId);

            var requestEntity = _requestRepo.Get(request.RequestId);

            var user = requestEntity.User;
            var trainer = requestEntity.Trainer;

            _bus.Publish(new TrainingRequestAccepted
            {
                TrainerEmail = trainer.Email,
                TrainerFirstName = trainer.FirstName,
                TrainerLastName = trainer.LastName,
                UserFirstName = user.FirstName,
                UserLastName = user.LastName,
                UserUsername = user.Username
            });

            return Unit.Task;
        }
    }
}