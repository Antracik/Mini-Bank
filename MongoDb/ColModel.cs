using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MongoDb
{
    public class ColModel
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public DateTime Date { get; set; }
        [BsonElement("Level")]
        public string LogLevel { get; set; }
        public string Data { get; set; }
        public string Logger { get; set; }
        public string CallSite { get; set; }
        public string StackTrace { get; set; }
        public BsonDocument Properties { get; set; }
    }
}
