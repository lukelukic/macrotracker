using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Domain;
using MacroTracker.Users.Infrastructure;

namespace Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.Repositories
{
    public class EfUserRepository : EfGenericRepository<User>, IUserRepository
    {
        public EfUserRepository(UsersDbContext context) : base(context)
        {
        }
    }
}