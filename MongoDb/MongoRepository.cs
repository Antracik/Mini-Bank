using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Shared;

namespace MongoDb
{
    public class MongoRepository : IMongoRepository
    {
        private readonly MongoDbContext _context = null;

        public MongoRepository(IOptions<MongoDbSettings> settings) 
        {
            _context = new MongoDbContext(settings);
        }

        public IEnumerable<ColModel> GetAll()
        {
            return _context.DbChanges.Find(new BsonDocument()).ToList();
        }

        public IEnumerable<ColModel> GetByDate(DateTime dateTime)
        {
            var filter = Builders<ColModel>.Filter.Eq("Date",dateTime);
            var result = _context.DbChanges.Find(filter).ToList();

            return result;
        }

        public ColModel GetById(string id)
        {
            ObjectId internalId = GetInternalId(id);
            return  _context.DbChanges
                            .Find(change =>  change.InternalId == internalId)
                            .FirstOrDefault();
        }

        private ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }
    }
}
