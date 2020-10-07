using MongoDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.Implementations
{
    public class MongoLoggerService : IMongoLoggerService
    {
        private readonly IMongoRepository _repository;

        public MongoLoggerService(IMongoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ColModel> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<ColModel> GetByDate(DateTime dateTime)
        {
            return _repository.GetByDate(dateTime);
        }

        public ColModel GetById(string id)
        {
            return _repository.GetById(id);
        }

        public object GetInstance(string fullyQualifiedName)
        {
            Type type = Type.GetType(fullyQualifiedName);
            if (type != null)
                return Activator.CreateInstance(type);
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType(fullyQualifiedName);
                if (type != null)
                    return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}
