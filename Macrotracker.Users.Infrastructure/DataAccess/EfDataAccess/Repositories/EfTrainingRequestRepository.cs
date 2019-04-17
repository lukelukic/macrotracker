using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Domain.Entities;
using MacroTracker.Users.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.Repositories
{
    public class EfTrainingRequestRepository : EfGenericRepository<TrainingRequest>, ITrainingRequestRepository
    {
        [ExcludeFromCodeCoverage]
        public EfTrainingRequestRepository(UsersDbContext context) : base(context)
        {
        }
    }
}