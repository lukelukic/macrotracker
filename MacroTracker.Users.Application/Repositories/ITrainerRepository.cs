using MacroTracker.Users.Domain.Entities;
using System;

namespace MacroTracker.Users.Application.Repositories
{
    public interface ITrainerRepository : IRepository<Trainer>
    {
        void AcceptTrainingRequest(Guid requestId);
    }
}