using MediatR;
using System;

namespace MacroTracker.Users.Application.UseCases.Trainers.DeactivateTrainer
{
    public class DeactivateTrainerRequest : IRequest
    {
        public Guid TrainerId { get; set; }
    }
}