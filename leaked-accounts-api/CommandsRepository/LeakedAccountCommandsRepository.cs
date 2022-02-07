using leaked_account_api.CommandsAbstraction;
using leaked_account_api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace leaked_account_api.CommandsRepository
{
    public class LeakedAccountCommandsRepository : ILeakedAccountCommandsRepository
    {
        private static IMongoCollection<LeakedAccount> _collection;
        public LeakedAccountCommandsRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");
            var database = client.GetDatabase("credentials");
            _collection = database.GetCollection<LeakedAccount>("leakedAccount");

        }
        public void DeleteLeakedAccount(string mail)
        {
            var builder = Builders<LeakedAccount>.Filter;
            var filter = builder.Eq("email", mail);
            var result = _collection.DeleteMany(filter);
        }

        public void UpdateLeakedAccount(string Id, string mail)
        {
            var builder = Builders<LeakedAccount>.Filter;
            var filter = builder.Eq("_id", ObjectId.Parse(Id));
            var update = Builders<LeakedAccount>.Update.Set("email",mail);
            var result = _collection.UpdateOne(filter,update);
        }
    }
}
