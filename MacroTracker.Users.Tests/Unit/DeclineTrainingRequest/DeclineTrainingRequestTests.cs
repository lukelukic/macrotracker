using FluentAssertions;
using Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.Repositories;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Application.UseCases.Trainers.DeclineTrainingRequest;
using MacroTracker.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace MacroTracker.Users.Tests.Unit
{
    public class DeclineTrainingRequestTests : EfSqlLiteTest
    {
        [Fact]
        public void TrainingRequestDeclined()
        {
            var context = PrepareData();
            var request = context.TrainingRequests.First();
            context.Entry(request).State = EntityState.Detached;
            ITrainingRequestRepository repo = new EfTrainingRequestRepository(context);
            var handler = new DeclineTrainingRequestHandler(repo);
            handler.Handle(new DeclineTrainingRequestRequest { TrainingRequestId = request.Id }, new System.Threading.CancellationToken());
            context.TrainingRequests.Find(request.Id).IsActive.Should().BeFalse();
        }

        [Fact]
        public void TrainingRequestIsActive()
        {
            var context = PrepareData();
            context.TrainingRequests.First().IsActive.Should().BeTrue();
        }
        private UsersDbContext PrepareData()
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

            var trainerId = context.Trainers.First().Id;
            var userId = context.Users.First().Id;

            context.TrainingRequests.Add(new Domain.Entities.TrainingRequest
            {
                TrainerId = trainerId,
                UserId = userId
            });

            context.SaveChanges();

            return context;
        }
    }
}