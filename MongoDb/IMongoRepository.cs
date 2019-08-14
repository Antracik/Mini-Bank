using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDb
{
    public interface IMongoRepository
    {
        IEnumerable<ColModel> GetAll();
        ColModel GetById(string id);
        IEnumerable<ColModel> GetByDate(DateTime dateTime);

    }
}
