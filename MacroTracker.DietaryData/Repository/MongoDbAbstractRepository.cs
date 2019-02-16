using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MacroTracker.DietaryData.Repository
{
    public abstract class AbstractMongoRepository<T>
    {
        protected IMongoCollection<T> MongoCollection { get; }

        public AbstractMongoRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase(config.GetSection("Mongo")["DbName"]);
            MongoCollection = database.GetCollection<T>(CollectionName);
        }

        protected abstract string CollectionName { get; }
    }
}