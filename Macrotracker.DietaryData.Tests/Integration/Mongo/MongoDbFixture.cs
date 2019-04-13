using MacroTracker.DietaryData.Models;
using MacroTracker.DietaryData.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Macrotracker.DietaryData.Tests.Integration.Mongo
{
    public class MongoFoodEntriesDbFixture : IDisposable
    {
        private readonly IMongoCollection<FoodEntryModel> _collection;
        public readonly FoodEntryMongoRepository Repo;

        public MongoFoodEntriesDbFixture()
        {
            var client = new MongoClient(MongoParams.ConnectionString);
            var database = client.GetDatabase(MongoParams.DbName);
            _collection = database.GetCollection<FoodEntryModel>("FoodCollection");

            Repo = new FoodEntryMongoRepository(MongoParams.ConnectionString, MongoParams.DbName);


            _collection.InsertMany(new List<FoodEntryModel>
            {
                new FoodEntryModel
                {
                    AddedDate = DateTime.Now,
                    Carbohydrate = 100,
                    Fat = 50,
                    Protein = 200,
                    UserId = "fixture-test-1"
                },
                new FoodEntryModel
                {
                    AddedDate = DateTime.Now,
                    Carbohydrate = 110,
                    Fat = 50,
                    Protein = 200,
                    UserId = "fixture-test-2"
                },
                new FoodEntryModel
                {
                    AddedDate = DateTime.Now,
                    Carbohydrate = 120,
                    Fat = 50,
                    Protein = 200,
                    UserId = "fixture-test-3"
                },
                new FoodEntryModel
                {
                    AddedDate = DateTime.Now,
                    Carbohydrate = 130,
                    Fat = 50,
                    Protein = 200,
                    UserId = "fixture-test-4"
                },
            });
        }
        public void Dispose()
        {
            _collection.DeleteMany(d => d.UserId.Contains("fixture-test"));
        }

    }
}
