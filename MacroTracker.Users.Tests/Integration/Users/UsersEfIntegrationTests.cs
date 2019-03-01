using FluentAssertions;
using Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.Repositories;
using MacroTracker.Users.Domain;
using MacroTracker.Users.Infrastructure;
using MacroTracker.Users.Tests.Integration.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MacroTracker.Users.Tests.Integration.Users
{
    public class UsersEfRepositoryIntegrationTests : IClassFixture<EntityFrameworkFixture>
    {
        private readonly EntityFrameworkFixture _fixture;
        private readonly EfUserRepository _repo;
        public UsersEfRepositoryIntegrationTests(EntityFrameworkFixture fixture)
        {
            _fixture = fixture;

            var user1 = new User
            {
                Email = "pera@gmail.com",
                Username = "pera"
            };

            var user2 = new User
            {
                Email = "delete@gmail.com",
                Username = "delete"
            };

            
            _fixture.Context.Users.Add(user2);

            _fixture.Context.SaveChanges();

            _repo = new EfUserRepository(_fixture.Context);
            _repo.Add(user1);
        }

        [Fact]
        public void CanRetrieveUsers()
        {
            var user = _repo.Get(x => x.Email == "pera@gmail.com");
            user.Should().NotBeEmpty();
        }


        [Fact]
        public void CanDeleteUserById()
        {
            var user = _repo.Get(u => u.Email == "delete@gmail.com").FirstOrDefault();
            var id = user.Id;

            _repo.Delete(id);

            _repo.Get(id).Should().BeNull();
        }

        [Fact]
        public void CanRetrieveRangeUsers()
        {
            var users = _repo.Get(x => true, 2, 1);
            users.Should().HaveCount(2);
        }



    }
}
