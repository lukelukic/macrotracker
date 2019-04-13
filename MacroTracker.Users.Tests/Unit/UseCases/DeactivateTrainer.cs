using EventBus;
using FluentAssertions;
using MacroTracker.Users.Application;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Application.UseCases.Trainers.DeactivateTrainer;
using MacroTracker.Users.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MacroTracker.Users.Tests.Unit.UseCases
{
    public class DeactivateTrainer
    {

        [Fact]
        public void ThrowsExceptionWhenTrainerNotExists()
        {
            var mock = new Mock<ITrainerRepository>();
            mock.Setup(repo => repo.Get(It.IsAny<Guid>())).Returns<Trainer>(null);

            var handler = new DeactivateTrainerHandler(null, mock.Object);

            Action a = () => handler.Handle(new DeactivateTrainerRequest {TrainerId = Guid.NewGuid() }, new System.Threading.CancellationToken());

            a.Should().ThrowExactly<EntityNotFoundException>();

        }

        [Fact]
        public void ThrowsExceptionWhenTrainerIsAlreadyActive()
        {
            var mock = new Mock<ITrainerRepository>(); 
            mock.Setup(repo => repo.Get(It.IsAny<Guid>())).Returns(new Trainer { IsActive = false });

            var handler = new DeactivateTrainerHandler(null, mock.Object);

            Action a = () => handler.Handle(new DeactivateTrainerRequest { TrainerId = Guid.NewGuid() }, new System.Threading.CancellationToken());

            a.Should().ThrowExactly<EntityInactiveException>();

        }

        [Fact]
        public void ChangesTrainersIsActivePropertyToFalseWhenTrainerExistsAndIsActive()
        {
            var trainer = new Trainer { IsActive = true };

            var mock = new Mock<ITrainerRepository>();
            var eventBusMock = new Mock<IEventBus>();

            mock.Setup(repo => repo.Get(It.IsAny<Guid>())).Returns(trainer);

            var handler = new DeactivateTrainerHandler(eventBusMock.Object, mock.Object);

            var result = handler.Handle(new DeactivateTrainerRequest { }, new System.Threading.CancellationToken());

            trainer.IsActive.Should().BeFalse();
        }

    }
}
