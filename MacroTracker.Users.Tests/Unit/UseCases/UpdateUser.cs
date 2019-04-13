using FluentAssertions;
using MacroTracker.Users.Application;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Application.UseCases.Users;
using MacroTracker.Users.Application.UseCases.Users.UpdateUserUseCase;
using MacroTracker.Users.Domain;
using MacroTracker.Users.Tests.Fakers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MacroTracker.Users.Tests.Unit.UseCases
{
    public class UpdateUser
    {
        private User User => new UserFaker().GetOne;

        private Mock<IUserRepository> Mock
        {
            get
            {
                var mock = new Mock<IUserRepository>();
                return mock;
            }
        }


        private UpdateUserRequest Request => new UpdateUserRequest
        {
            Email = "pera@gmail.com",
            FirstName = "Petar",
            LastName = "Peric",
            UserId = Guid.NewGuid(),
            Username = "pera"
        };

        [Fact]
        public void ThrowsExceptionWhenUserDoesntExist()
        {
            var mock = Mock;
            mock.Setup(r => r.Get(It.IsAny<Guid>())).Returns<User>(null);

            var handler = new UpdateUserHandler(mock.Object);

            Action a = () => handler.Handle(Request, new System.Threading.CancellationToken());

            a.Should().Throw<EntityNotFoundException>();
        }

        [Fact]
        public void ThrowsExceptionWhenUserIsInactive()
        {
            var mock = Mock;
            mock.Setup(r => r.Get(It.IsAny<Guid>())).Returns(new User { IsActive = false });

            var handler = new UpdateUserHandler(mock.Object);

            Action a = () => handler.Handle(Request, new System.Threading.CancellationToken());

            a.Should().Throw<EntityInactiveException>();
        }

        [Fact]
        public void HandlerUpdatesUser()
        {
            var mock = Mock;
            var user = User;
            user.IsActive = true;
            var request = Request;

            mock.Setup(r => r.Get(It.IsAny<Guid>())).Returns(user);

            var handler = new UpdateUserHandler(mock.Object);

            handler.Handle(Request, new System.Threading.CancellationToken());

            user.FirstName.Should().BeSameAs(request.FirstName);
            user.LastName.Should().BeSameAs(request.LastName);
            user.Email.Should().BeSameAs(request.Email);
            user.Username.Should().BeSameAs(request.Username);

            mock.Verify(r => r.Get(It.IsAny<Guid>()), Times.Once);
        }
    }
}
