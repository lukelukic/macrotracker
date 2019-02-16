using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MacroTracker.Users.Application.UseCases.Trainers.DeclineTrainingRequest
{
    public class DeclineTrainingRequestHandler : IRequestHandler<DeclineTrainingRequestRequest>
    {
        private readonly ITrainingRequestRepository _requestRepo;

        public DeclineTrainingRequestHandler(ITrainingRequestRepository requestRepo) => _requestRepo = requestRepo;

        public Task<Unit> Handle(DeclineTrainingRequestRequest request, CancellationToken cancellationToken)
        {
            var requestEntry = _requestRepo.Get(request.TrainingRequestId);

            if (requestEntry == null)
                throw new EntityNotFoundException(request.TrainingRequestId, "Training Request");

            requestEntry.IsActive = false;

            _requestRepo.Update(requestEntry);

            return Unit.Task;
        }
    }
}
