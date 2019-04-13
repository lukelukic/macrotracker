using FluentAssertions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Application.UseCases.SearchUsers;
using MacroTracker.Users.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace MacroTracker.Users.Tests.Unit.UseCases
{
    public class SearchUsers
    {
        public IEnumerable<User> Users => new List<User>
        {
            new User { Id = Guid.NewGuid(), Username = "pera", LastName = "Peric", FirstName = "Petar", IsActive = true, Email = "mail" },
            new User { Id = Guid.NewGuid(), Username = "mika", LastName = "Mikic", FirstName = "Milorad", IsActive = true, Email = "mail" },
            new User { Id = Guid.NewGuid(), Username = "zika", LastName = "Zikic", FirstName = "Zivorad", IsActive = true, Email = "mail" },
            new User { Id = Guid.NewGuid(), Username = "inactive", LastName = "inactive", FirstName = "inactive", IsActive = false, Email = "mail" },
        };



        [Fact]
        public void RetreivesAllActiveUsersWhenNoKeywordIsSent()
        {
            var query = new SearchUsersQuery();

            Users.Where(query.AsQuery.Compile()).Should().HaveCount(3);
        }

        [Fact]
        public void ReteivesAllUsersThatContainWordA()
        {
            var query = new SearchUsersQuery {
                Keyword = "A"
            };

            Users.Where(query.AsQuery.Compile()).Should().HaveCount(3);
        }

        [Theory]
        [InlineData("per")]
        [InlineData("pera")]
        [InlineData("zi")]
        [InlineData("mika")]
        public void SearchWorksForPartOfUsername(string keyword)
        {
            var query = new SearchUsersQuery
            {
                Keyword = keyword
            };

            Users.Where(query.AsQuery.Compile()).Should().HaveCount(1);
        }

        [Theory]
        [InlineData("petar")]
        [InlineData("peta")]
        [InlineData("zivorad")]
        [InlineData("milor")]
        public void SearchWorksForPartOfFirstName(string keyword)
        {
            var query = new SearchUsersQuery
            {
                Keyword = keyword
            };

            Users.Where(query.AsQuery.Compile()).Should().HaveCount(1);
        }

        [Theory]
        [InlineData("PERI")]
        [InlineData("peric")]
        [InlineData("miki")]
        [InlineData("zikiC")]
        public void SearchWorksForPartOffLastName(string keyword)
        {
            var query = new SearchUsersQuery
            {
                Keyword = keyword
            };

            Users.Where(query.AsQuery.Compile()).Should().HaveCount(1);
        }

        [Fact]
        public void HandlerRetrievesAppropriateData()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(repo => repo.Get(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Users.Where(u => u.IsActive));
            var handler = new SearchUserHandler(mock.Object);

            var response = handler.Handle(new SearchUsersQuery {
                PageNumber = 1, PerPage = 1
            }, new System.Threading.CancellationToken());

            response.Result.Should().HaveCount(3);

            foreach(var u in response.Result)
            {
                u.Id.ToString().Should().NotBeNullOrEmpty();
                u.FirstName.Should().NotBeNull();
                u.LastName.Should().NotBeNull();
                u.Email.Should().NotBeNull();
            }
        } 

    }
}
