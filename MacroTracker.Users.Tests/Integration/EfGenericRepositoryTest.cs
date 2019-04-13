using FluentAssertions;
using Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.Repositories;
using MacroTracker.Users.Infrastructure;
using MacroTracker.Users.Tests.Fakers;
using MacroTracker.Users.Tests.Integration.Database;
using MacroTracker.Users.Tests.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MacroTracker.Users.Tests.Integration
{
    public class EfGenericRepositoryTest : IClassFixture<EntityFrameworkFixture>
    {
        private readonly EntityFrameworkFixture _fixture;
        public EfGenericRepositoryTest(EntityFrameworkFixture fixture)
        {
            _fixture = fixture;
            _fixture.Context.Users.Add(new UserFaker().GetOne);
            _fixture.Context.SaveChanges();
        }
        

        [Fact]
        public void GenericUpdateEntityWorks()
        {
            var user = _fixture.Context.Users.FirstOrDefault();

            user.Should().NotBeNull();

            var repo = new EfUserRepository(_fixture.Context);

            user.FirstName = "Luka";

            repo.Update(user);

            var updated = _fixture.Context.Users.FirstOrDefault();
            updated.FirstName.Should().Be("Luka");
        }
    }
}
