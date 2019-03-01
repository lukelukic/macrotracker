using EventBus;
using EventBus.Events;
using FluentAssertions;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Application.UseCases;
using MacroTracker.Users.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace MacroTracker.Users.Tests.Unit.RegisterUserUseCaseTests
{
    public class RegisterUserUseCaseTest
    {
        private Mock<IUserRepository> _repoMock = new Mock<IUserRepository>();
        private Mock<IEventBus> _busMock = new Mock<IEventBus>();
        [Fact]

        public void ThrowsExceptionWhenEmailIsAlreadyInUse()
        {
            _repoMock.Setup(r => r.Get(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new List<User> { new User { } });

            var handler = new RegisterUserHandler(null, _repoMock.Object);

            Action action = () => handler.Handle(Request, new System.Threading.CancellationToken());

            action.Should().ThrowExactly<EntityAlreadyExistsException>().WithMessage("test@gmail.com is already in use.");

        }

        [Fact]
        public void ThrowsExceptionUsernameExists()
        {
            _repoMock.SetupSequence(r => r.Get(It.IsAny<Expression<Func<User, bool>>>()))
               .Returns(new List<User>())
               .Returns(new List<User> { new User { } });

            var handler = new RegisterUserHandler(null, _repoMock.Object);

            Action action = () => handler.Handle(Request, new System.Threading.CancellationToken());

            action.Should().ThrowExactly<EntityAlreadyExistsException>().WithMessage("pera is already in use.");

        }

        [Fact]
        public void CallRepoAddAndPublishesEventWhenDataIsValid()
        {
            _repoMock.Setup(r => r.Get(It.IsAny<Expression<Func<User, bool>>>()))
               .Returns(new List<User>());

            _repoMock.Setup(r => r.Add(It.IsAny<User>()));
            _busMock.Setup(r => r.Publish(It.IsAny<UserRegisteredEvent>()));

            var handler = new RegisterUserHandler(_busMock.Object, _repoMock.Object);

            handler.Handle(Request, new System.Threading.CancellationToken());

            _repoMock.Verify(r => r.Add(It.IsAny<User>()), Times.Once);
            _busMock.Verify(r => r.Publish(It.IsAny<UserRegisteredEvent>()), Times.Once);
        }

        public RegisterUserUseCase Request =>
            new RegisterUserUseCase
            {
                Email = "test@gmail.com",
                FirstName = "Pera",
                LastName = "Peric",
                Password = "sifra1",
                Username = "pera"
            };
    }
}

