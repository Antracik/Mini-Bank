using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared;

namespace MongoDb
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<ColModel> DbChanges
        {
            get
            {
                return _database.GetCollection<ColModel>("DatabaseChanges");
            }
        }
        
    }
}
