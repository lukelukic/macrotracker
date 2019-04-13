using FluentAssertions;
using MacroTracker.DietaryData.Models;
using MacroTracker.DietaryData.Queries;
using MacroTracker.DietaryData.Repository;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Macrotracker.DietaryData.Tests.Integration.Mongo
{
    public class MongoFoodEntriesRepositoryTests : IClassFixture<MongoFoodEntriesDbFixture>
    {
        private MongoFoodEntriesDbFixture _fixture;
        public MongoFoodEntriesRepositoryTests(MongoFoodEntriesDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void InsertFindGetDeleteWorks()
        {
            var model = new FoodEntryModel
            {
                AddedDate = DateTime.Now,
                Fat = 10,
                Protein = 30,
                Carbohydrate = 40,
                UserId = "testId",
                KCal = 244,
            };

           _fixture.Repo.Insert(model);

            var inserted =_fixture.Repo.Get(x => x.UserId == "testId").First();

            inserted.Should().NotBeNull();

            var objectById =_fixture.Repo.Find(inserted.Id.ToString());

            objectById.Should().NotBeNull();

           _fixture.Repo.Delete(inserted.Id.ToString());

            var deleted =_fixture.Repo.Get(x => x.UserId == "testId").FirstOrDefault();

            deleted.Should().BeNull();
        }

        [Fact]
        public void CanUpdateEntry()
        {
            var inserted =_fixture.Repo.Get(x => x.UserId == "fixture-test-4").First();

            inserted.Carbohydrate = 50;
            inserted.UserId = "fixture-test-4-updated";

           _fixture.Repo.Update(inserted);

            var updated =_fixture.Repo.Find(inserted.Id.ToString());

            updated.UserId.Should().Be("fixture-test-4-updated");
            updated.Carbohydrate.Should().Be(50);
        }

        [Fact]
        public void DietaryDataQueryRetrievesAppropriateData()
        {
            var query = new DietaryDataQuery
            {
                UserId = "fixture-test-3",
                StartDate = new DateTime(2018, 1, 1),
                EndDate = DateTime.Now
            };

            _fixture.Repo.Get(query).Should().HaveCount(1);

        }
    }
}
