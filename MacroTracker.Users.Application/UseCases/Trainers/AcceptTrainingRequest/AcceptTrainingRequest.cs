using MediatR;
using System;

namespace MacroTracker.Users.Application.UseCases.Trainers.AcceptTrainingRequest
{
    public class AcceptTrainingRequest : IRequest
    {
        public Guid RequestId { get; set; }
    }
}