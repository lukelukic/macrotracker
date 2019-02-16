using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Domain;
using MacroTracker.Users.Domain.Entities;
using MacroTracker.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.Repositories
{
    public class EfTrainerRepository : EfGenericRepository<Trainer>, ITrainerRepository
    {
        public EfTrainerRepository(UsersDbContext context) : base(context)
        {
        }

        public void AcceptTrainingRequest(Guid requestId)
        {
            var request = Context.TrainingRequests.
                Include(tr => tr.Trainer)
                .ThenInclude(t => t.TrainerUsers).Where(r => r.Id == requestId).FirstOrDefault();

            if (request == null)
                throw new EntityNotFoundException(requestId, "TrainingRequest");

            if (request.Trainer.TrainerUsers.Any(tu => tu.UserId == request.UserId))
                throw new EntityAlreadyExists("Trainer and user are already connected.");

            var userTrainer = new TrainerUser
            {
                TrainerId = request.TrainerId,
                UserId = request.UserId
            };

            request.IsActive = false;

            Context.Entry(userTrainer).State = EntityState.Added;

            Context.SaveChanges();
        }
    }
}