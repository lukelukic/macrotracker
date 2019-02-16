using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Domain.Entities;
using MacroTracker.Users.Infrastructure;

namespace Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.Repositories
{
    public class EfTrainingRequestRepository : EfGenericRepository<TrainingRequest>, ITrainingRequestRepository
    {
        public EfTrainingRequestRepository(UsersDbContext context) : base(context)
        {
        }
    }
}