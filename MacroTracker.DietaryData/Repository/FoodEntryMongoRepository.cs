using MacroTracker.DietaryData.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MacroTracker.DietaryData.Repository
{
    public class FoodEntryMongoRepository : AbstractMongoRepository<FoodEntryModel>, IFoodEntryRepository
    {
        public FoodEntryMongoRepository(IConfiguration config) : base(config)
        {
        }

        public FoodEntryMongoRepository(string connectionString, string dbName) : base(connectionString, dbName)
        {

        }
        protected override string CollectionName => "FoodCollection";

        public void Delete(string objectId) => MongoCollection.DeleteOne(x => x.Id == ObjectId.Parse(objectId));

        public IEnumerable<FoodEntryModel> Get(Expression<Func<FoodEntryModel, bool>> predicate) => 
            MongoCollection
            .Find(predicate)
            .ToList();

        public void Insert(FoodEntryModel entity) => MongoCollection.InsertOne(entity);

        public void Update(FoodEntryModel entity) => MongoCollection.ReplaceOne(e => e.Id == entity.Id, entity);

        public FoodEntryModel Find(string entryId) =>
            MongoCollection
            .Find(e => e.Id == ObjectId.Parse(entryId))
            .FirstOrDefault();
    }
}