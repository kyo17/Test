using System;
using MongoDB.Driver;

namespace Mongodb
{
    public class Mongod
    {
        public MongoClient client;
        public IMongoDatabase db;
        public Mongod()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("AnimeWorld");
        }
    }
}
