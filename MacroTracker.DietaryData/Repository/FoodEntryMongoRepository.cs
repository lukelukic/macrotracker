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
    public class FoodEntryMongoRepository : AbstractMongoRepository<FoodEntry>, IFoodEntryRepository
    {
        public FoodEntryMongoRepository(IConfiguration config) : base(config)
        {
        }

        protected override string CollectionName => "FoodCollection";

        public void Delete(string objectId) => MongoCollection.DeleteOne(x => x.Id == ObjectId.Parse(objectId));

        public IEnumerable<FoodEntry> Get(Expression<Func<FoodEntry, bool>> predicate) => 
            MongoCollection
            .Find(predicate)
            .ToList();

        public void Insert(FoodEntry entity) => MongoCollection.InsertOne(entity);

        public void Update(FoodEntry entity) => MongoCollection.ReplaceOne(e => e.Id == entity.Id, entity);

        public FoodEntry Find(string userId, string entryId) =>
            MongoCollection
            .Find(e => e.Id == ObjectId.Parse(entryId) && e.UserId == userId)
            .FirstOrDefault();
    }
}