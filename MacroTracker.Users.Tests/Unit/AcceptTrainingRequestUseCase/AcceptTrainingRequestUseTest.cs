using FluentAssertions;
using Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.Repositories;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TestSupport.EfHelpers;
using Xunit;

namespace MacroTracker.Users.Tests.Unit.AcceptTrainingRequestUseCase
{
    public class AcceptTrainingRequestUseTest : EfSqlLiteTest
    {
        private ITrainerRepository _trainerRepository;

        [Fact]
        public void AcceptTrainingRequestWorks()
        {
            var context = GetContext();
            var trainerId = context.Trainers.First().Id;
            var userId = context.Users.First().Id;

            context.TrainingRequests.Add(new Domain.Entities.TrainingRequest
            {
                TrainerId = trainerId,
                UserId = userId
            });

            context.SaveChanges();

            var requestId = context.TrainingRequests.First().Id;

            _trainerRepository = new EfTrainerRepository(context);

            _trainerRepository.AcceptTrainingRequest(requestId);

            context.TrainingRequests.Find(requestId).IsActive.Should().BeFalse();
            context.Trainers
                .Include(t => t.TrainerUsers)
                .Where(t => t.Id == trainerId)
                .First()
                .TrainerUsers
                .Any().Should().BeTrue();
        }

        [Fact]
        public void TestInMemoryDb() => GetContext().Trainers.Should().HaveCount(1);

        [Fact]
        public void ThrowsExceptionWhenRequestedGuidDoesntExist()
        {
            _trainerRepository = new EfTrainerRepository(GetContext());

            Assert.Throws<EntityNotFoundException>(() => _trainerRepository.AcceptTrainingRequest(new Guid()));
        }

        [Fact]
        public void ThrowsExceptionWhenTrainerAndUserAreAlreadyConnected()
        {
            var context = GetContext();
            var trainerId = context.Trainers.First().Id;
            var userId = context.Users.First().Id;

            context.TrainingRequests.Add(new Domain.Entities.TrainingRequest
            {
                TrainerId = trainerId,
                UserId = userId
            });

            context.Trainers.Include(t => t.TrainerUsers)
                .First()
                .TrainerUsers
                .Add(new Domain.TrainerUser
                {
                    TrainerId = trainerId,
                    UserId = userId
                });

            context.SaveChanges();

            var requestId = context.TrainingRequests.First().Id;

            _trainerRepository = new EfTrainerRepository(context);

            Assert.Throws<EntityAlreadyExistsException>(() => _trainerRepository.AcceptTrainingRequest(requestId));
        }

        private UsersDbContext GetContext()
        {
            var context = CreateDbContext();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            context.Users.Add(new Domain.User
            {
                Email = "luka.lukic@ict.edu.rs",
                FirstName = "Luka",
                LastName = "Lukic",
                Password = "Sifra1233",
                Username = "Luke222",
            });

            context.Trainers.Add(new Domain.Entities.Trainer
            {
                Email = "luka.lukic1@ict.edu.rs",
                FirstName = "Luka1",
                LastName = "Lukic1",
                Password = "Sifra1233",
                Username = "luke",
            });

            context.SaveChanges();

            return context;
        }
    }
}