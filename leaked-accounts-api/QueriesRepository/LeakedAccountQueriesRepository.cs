using MongoDB.Driver;
using leaked_account_api.Models;
using leaked_account_api.QueriesAbstraction;
using System;
using System.Linq;
using MongoDB.Bson;

namespace leaked_account_api.QueriesRepository
{
    public class LeakedAccountQueriesRepository : ILeakedAccountQueriesRepository
    {
        private static IMongoCollection<LeakedAccount> _collection;
        public LeakedAccountQueriesRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");
            var database = client.GetDatabase("credentials");
            _collection = database.GetCollection<LeakedAccount>("leakedAccount");

        }
        public bool GetLeakedAccountByEmail(string mail)
        {
            var builder = Builders<LeakedAccount>.Filter;
            var filter = builder.And(builder.Eq("email", mail));
            var result = _collection.Find(filter).ToList();
            return result.Any();
        }

        public bool GetLeakedAccountById(string Id)
        {
            var builder = Builders<LeakedAccount>.Filter;
            var filter = builder.And(builder.Eq("_id", ObjectId.Parse(Id)));
            var result = _collection.Find(filter).ToList();
            return result.Any();
        }

        public bool GetLeakedAccountByEmailAndPassword(string mail, string pass)
        {
            var builder = Builders<LeakedAccount>.Filter;
            var filter = builder.And(builder.Eq("email", mail), builder.Eq("passwords", pass));
            var result = _collection.Find(filter).ToList();
            return result.Any();
        }
    }
}
