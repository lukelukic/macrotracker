using EventBus;
using EventBus.Events;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Application.UseCases.Trainers.AcceptTrainingRequest;
using MacroTracker.Users.Domain;
using MacroTracker.Users.Tests.Fakers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MacroTracker.Users.Tests.Unit.UseCases
{
    public class AcceptTrainingRequest
    {
        [Fact]
        public void AcceptTrainingRequestCallsAppropriateMethods()
        {
            var trainerRepoMock = new Mock<ITrainerRepository>();
            var busMock = new Mock<IEventBus>();
            var trainingRequestRepoMock = new Mock<ITrainingRequestRepository>();

            trainingRequestRepoMock.Setup(r => r.Get(It.IsAny<Guid>())).Returns(new Domain.Entities.TrainingRequest
            {
                Trainer = new TrainerFaker().GetOne,
                User = new UserFaker().GetOne
            });

            var handler = new AcceptTrainingRequestHandler(busMock.Object, trainerRepoMock.Object, trainingRequestRepoMock.Object);



            handler.Handle(new Application.UseCases.Trainers.AcceptTrainingRequest.AcceptTrainingRequest
            {
                RequestId = Guid.NewGuid()
            }, new System.Threading.CancellationToken());

            trainerRepoMock.Verify(r => r.AcceptTrainingRequest(It.IsAny<Guid>()), Times.Once);
            trainingRequestRepoMock.Verify(r => r.Get(It.IsAny<Guid>()), Times.Once);
            busMock.Verify(b => b.Publish(It.IsAny<TrainingRequestAccepted>()), Times.Once);


        }
    }
}
