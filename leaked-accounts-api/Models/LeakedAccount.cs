using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace leaked_account_api.Models
{
    public class LeakedAccount
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("email")]
        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; }
        [BsonElement("passwords")]
        public List<string> Passwords { get; set; }
        [BsonElement("integration")]
        [BsonDateTimeOptions(Representation = BsonType.DateTime)]
        public DateTime Integration { get; set; }
    }
}
