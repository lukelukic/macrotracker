using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacroTracker.Users.Application.UseCases.Trainers.DeclineTrainingRequest
{
    public class DeclineTrainingRequestRequest : IRequest
    {
        public Guid TrainingRequestId { get; set; }
    }
}
