using FluentAssertions;
using Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.Repositories;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Application.UseCases.Trainers.DeclineTrainingRequest;
using MacroTracker.Users.Domain.Entities;
using MacroTracker.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace MacroTracker.Users.Tests.Unit
{
    public class DeclineTrainingRequestTests : EfSqlLiteTest
    {
        [Fact]
        public void TrainingRequestDeclined()
        {
            var mock = new Mock<ITrainingRequestRepository>();
            var entry = new TrainingRequest
            {
                IsActive = true
            };

            mock.Setup(r => r.Get(It.IsAny<Guid>())).Returns(entry);

            var handler = new DeclineTrainingRequestHandler(mock.Object);

            handler.Handle(new DeclineTrainingRequestRequest { TrainingRequestId = Guid.NewGuid() }, new System.Threading.CancellationToken());
            entry.IsActive.Should().BeFalse();
        }

        [Fact]
        public void ThrowsExceptionWhenRequestEntryIsNull()
        {
            var mock = new Mock<ITrainingRequestRepository>();

            mock.Setup(r => r.Get(It.IsAny<Guid>())).Returns<TrainingRequest>(null);

            var handler = new DeclineTrainingRequestHandler(mock.Object);

            Action a = () => handler.Handle(new DeclineTrainingRequestRequest { TrainingRequestId = Guid.NewGuid() }, new System.Threading.CancellationToken());

            a.Should().ThrowExactly<EntityNotFoundException>();
        }

    }
}