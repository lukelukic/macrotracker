using MediatR;
using System;

namespace MacroTracker.Users.Application.UseCases.Users.SendTrainingRequest
{
    public class SendTrainingRequestRequest : IRequest
    {
        public Guid TrainerId { get; set; }
        public Guid UserId { get; set; }
    }
}