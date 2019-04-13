using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using MacroTracker.Users.Application.UseCases.RegisterTrainer;
using MacroTracker.Users.Application.Repositories;
using Moq;
using System.Linq.Expressions;
using MacroTracker.Users.Domain.Entities;
using MacroTracker.Users.Application.Exceptions;
using EventBus;
using EventBus.Events;

namespace MacroTracker.Users.Tests.Unit.RegisterTrainerUseCase
{
    public class RegisterTrainerUseCaseTest
    {
        private Mock<ITrainerRepository> _repoMock = new Mock<ITrainerRepository>();
        private Mock<IEventBus> _busMock = new Mock<IEventBus>();
        [Fact]

        public void ThrowsExceptionWhenEmailIsAlreadyInUse()
        {
            _repoMock.Setup(r => r.Get(It.IsAny<Expression<Func<Trainer, bool>>>()))
                .Returns(new List<Trainer> { new Trainer { } });

            var handler = new RegisterTrainerHandler(null, _repoMock.Object);

            Action action = () => handler.Handle(Request, new System.Threading.CancellationToken());

            action.Should().ThrowExactly<EntityAlreadyExistsException>().WithMessage("test@gmail.com is already in use.");

        }

        [Fact]
        public void ThrowsExceptionUsernameExists()
        {
            _repoMock.SetupSequence(r => r.Get(It.IsAny<Expression<Func<Trainer, bool>>>()))
               .Returns(new List<Trainer>())
               .Returns(new List<Trainer> { new Trainer { } });

            var handler = new RegisterTrainerHandler(null, _repoMock.Object);

            Action action = () => handler.Handle(Request, new System.Threading.CancellationToken());

            action.Should().ThrowExactly<EntityAlreadyExistsException>().WithMessage("pera is already in use.");

        }

        [Fact]
        public void CallRepoAddAndPublishesEventWhenDataIsValid()
        {
            _repoMock.Setup(r => r.Get(It.IsAny<Expression<Func<Trainer, bool>>>()))
               .Returns(new List<Trainer>());

            _repoMock.Setup(r => r.Add(It.IsAny<Trainer>()));
            _busMock.Setup(r => r.Publish(It.IsAny<UserRegisteredEvent>()));

            var handler = new RegisterTrainerHandler(_busMock.Object, _repoMock.Object);

            handler.Handle(Request, new System.Threading.CancellationToken());

            _repoMock.Verify(r => r.Add(It.IsAny<Trainer>()), Times.Once);
            _busMock.Verify(r => r.Publish(It.IsAny<UserRegisteredEvent>()), Times.Once);
        }

        public RegisterTrainerRequest Request =>
            new RegisterTrainerRequest
            {
                Email = "test@gmail.com",
                FirstName = "Pera",
                LastName = "Peric",
                Password = "sifra1",
                Username = "pera"
            };
    }
}
