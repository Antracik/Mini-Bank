using MongoDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public interface IMongoLoggerService : IMongoRepository
    {
        object GetInstance(string fullyQuallifiedName);
    }
}
