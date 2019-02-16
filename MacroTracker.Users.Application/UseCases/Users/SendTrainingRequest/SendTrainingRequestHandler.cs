using EventBus;
using EventBus.Events;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MacroTracker.Users.Application.UseCases.Users.SendTrainingRequest
{
    public class SendTrainingRequestHandler : IRequestHandler<SendTrainingRequestRequest>
    {
        private readonly IUserRepository _userRepo;
        private readonly ITrainerRepository _trainerRepo;
        private readonly ITrainingRequestRepository _requestRepo;
        private readonly IEventBus _eventBus;

        public SendTrainingRequestHandler(IUserRepository userRepo, ITrainerRepository trainerRepo, ITrainingRequestRepository requestRepo, IEventBus eventBus)
        {
            _userRepo = userRepo;
            _trainerRepo = trainerRepo;
            _requestRepo = requestRepo;
            _eventBus = eventBus;
        }

        public async Task<Unit> Handle(SendTrainingRequestRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepo.Get(request.UserId);
            if (user == null)
                throw new EntityNotFoundException(request.UserId, "User");

            var trainer = _trainerRepo.Get(request.TrainerId);
            if (trainer == null)
                throw new EntityNotFoundException(request.TrainerId, "Trainer");

            if (_requestRepo.Get(r => r.TrainerId == request.TrainerId && r.UserId == r.UserId && r.IsActive).Any())
                throw new EntityAlreadyExists("Request to this trainer has already been sent and is waiting for response.");

            _requestRepo.Add(new TrainingRequest
            {
                TrainerId = request.TrainerId,
                UserId = request.UserId
            });

            _eventBus.Publish(new TrainingRequestRecieved
            {
                TrainerEmail = trainer.Email,
                TrainerFirstName = trainer.FirstName,
                TrainerLastName = trainer.LastName,
                UserFirstName = user.FirstName,
                UserLastName = user.LastName,
                UserUsername = user.Username
            });

            return Unit.Value;
        }
    }
}