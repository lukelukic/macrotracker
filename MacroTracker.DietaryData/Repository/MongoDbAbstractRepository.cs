using MacroTracker.DietaryData.Queries;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MacroTracker.DietaryData.Repository
{
    public abstract class AbstractMongoRepository<T>
    {
        protected IMongoCollection<T> MongoCollection { get; }

        [ExcludeFromCodeCoverage]
        protected AbstractMongoRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase(config.GetSection("Mongo")["DbName"]);
            MongoCollection = database.GetCollection<T>(CollectionName);
        }

        protected AbstractMongoRepository(string connectionString, string DbName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(DbName);
            MongoCollection = database.GetCollection<T>(CollectionName);
        }

        protected abstract string CollectionName { get; }

        public IEnumerable<T> Get(BaseQuery<T> query) => MongoCollection
            .Find(query.GetQuery)
            .ToList();
    }
}