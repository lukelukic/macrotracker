using FluentAssertions;
using MacroTracker.DietaryData.Models;
using MacroTracker.DietaryData.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Macrotracker.DietaryData.Tests.Unit.Queries
{
    public class DataDietaryQueryTests
    {
        public IEnumerable<FoodEntryModel> Items => new List<FoodEntryModel>
        {
            new FoodEntryModel {AddedDate = new DateTime(2018, 1, 4), UserId = "test"},
            new FoodEntryModel {AddedDate = new DateTime(2018, 2, 4), UserId = "test"},
            new FoodEntryModel {AddedDate = new DateTime(2018, 3, 4), UserId = "test"},
            new FoodEntryModel {AddedDate = new DateTime(2018, 3, 15), UserId = "test"},
            new FoodEntryModel {AddedDate = new DateTime(2018, 3, 15), UserId = "test1"},
            new FoodEntryModel {AddedDate = new DateTime(2019, 3, 15), UserId = "test1"}
        };

        [Fact]
        public void QueryReturnsAllItemsForUser()
        {
            var query = new DietaryDataQuery
            {
                StartDate = new DateTime(2018, 1, 1),
                EndDate = DateTime.Now,
                UserId = "test"
            };

            var result = Items.Where(query.GetQuery.Compile());

            result.Should().HaveCount(4);
        }

        [Fact]
        public void QueryReturnsItemsForUserInSpecificTimeFrame()
        {
            var query = new DietaryDataQuery
            {
                StartDate = new DateTime(2018, 1, 1),
                EndDate = new DateTime(2018, 3, 5),
                UserId = "test"
            };

            var result = Items.Where(query.GetQuery.Compile());

            result.Should().HaveCount(3);

            foreach(var r in result)
            {
                r.AddedDate.Should().BeAfter(query.StartDate);
                r.AddedDate.Should().BeBefore(query.EndDate);
            }
        }
    }
}
