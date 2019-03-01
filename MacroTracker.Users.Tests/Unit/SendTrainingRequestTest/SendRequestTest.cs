using EventBus;
using EventBus.Events;
using FluentAssertions;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Application.UseCases.Users.SendTrainingRequest;
using MacroTracker.Users.Domain;
using MacroTracker.Users.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace MacroTracker.Users.Tests.Unit.SendTrainingRequestTest
{
    public class SendRequestTest
    {
        [Fact]
        public void ThrowsExceptionWhenUserIsNull()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(ur => ur.Get(It.IsAny<Guid>())).Returns<User>(null);

            var handler = new SendTrainingRequestHandler(mock.Object, null, null, null);

            Action action = () => handler.Handle(Request, new System.Threading.CancellationToken());

            action.Should().Throw<EntityNotFoundException>();
        }

        [Fact]
        public void ThrowsExceptionWhenTrainer()
        {

            var userMock = new Mock<IUserRepository>();
            userMock.Setup(ur => ur.Get(It.IsAny<Guid>())).Returns(new User { });

            var trainerMOck = new Mock<ITrainerRepository>();
            trainerMOck.Setup(tr => tr.Get(It.IsAny<Guid>())).Returns<User>(null);

            var handler = new SendTrainingRequestHandler(userMock.Object, trainerMOck.Object, null, null);

            Action action = () => handler.Handle(Request, new System.Threading.CancellationToken());

            action.Should().Throw<EntityNotFoundException>();
        }

        [Fact]
        public void ThrowsEntityALreadyExistsIfRequestIsPending()
        {

            var userMock = new Mock<IUserRepository>();
            userMock.Setup(ur => ur.Get(It.IsAny<Guid>())).Returns(new User { });

            var trainerMOck = new Mock<ITrainerRepository>();
            trainerMOck.Setup(tr => tr.Get(It.IsAny<Guid>())).Returns(new Trainer { });

            var requestMock = new Mock<ITrainingRequestRepository>();
            requestMock.Setup(tr => tr.Get(It.IsAny<Expression<Func<TrainingRequest, bool>>>())).Returns(new List<TrainingRequest> { new TrainingRequest() });

            var handler = new SendTrainingRequestHandler(userMock.Object, trainerMOck.Object, requestMock.Object, null);

            Action action = () => handler.Handle(Request, new System.Threading.CancellationToken());

            action.Should().Throw<EntityAlreadyExistsException>();
        }

        [Fact]
        public void RepoAddAndEventPublisMethodsAreCalled()
        {

            var userMock = new Mock<IUserRepository>();
            userMock.Setup(ur => ur.Get(It.IsAny<Guid>())).Returns(new User { });

            var trainerMOck = new Mock<ITrainerRepository>();
            trainerMOck.Setup(tr => tr.Get(It.IsAny<Guid>())).Returns(new Trainer { });

            var requestMock = new Mock<ITrainingRequestRepository>();
            requestMock.Setup(tr => tr.Get(It.IsAny<Expression<Func<TrainingRequest, bool>>>())).Returns(new List<TrainingRequest>());

            requestMock.Setup(r => r.Add(It.IsAny<TrainingRequest>()));

            var eventMock = new Mock<IEventBus>();
            eventMock.Setup(e => e.Publish(It.IsAny<TrainingRequestRecieved>()));

            

            var handler = new SendTrainingRequestHandler(userMock.Object, trainerMOck.Object, requestMock.Object, eventMock.Object);
            handler.Handle(Request, new System.Threading.CancellationToken());

            requestMock.Verify(r => r.Add(It.IsAny<TrainingRequest>()), Times.Once);
            eventMock.Verify(r => r.Publish(It.IsAny<TrainingRequestRecieved>()), Times.Once);

        }

        private SendTrainingRequestRequest Request => new SendTrainingRequestRequest
        {
            TrainerId = Guid.NewGuid(),
            UserId = Guid.NewGuid()
        };

        
    }
}
