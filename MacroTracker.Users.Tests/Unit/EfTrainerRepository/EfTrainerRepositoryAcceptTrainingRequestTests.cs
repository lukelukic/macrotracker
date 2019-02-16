using Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.Repositories;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Domain.Entities;
using MacroTracker.Users.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MacroTracker.Users.Tests.Unit.EfTrainerRepositoryTests
{
    public class EfTrainerRepositoryAcceptTrainingRequestTests
    {
        private UsersDbContext _context;

        public EfTrainerRepositoryAcceptTrainingRequestTests()
        {
            
        }

        [Fact]
        public void ThrowsExceptionWhenRequestIsNull()
        {
            
        }
    }
}
