using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace billingapi.Models
{
    public class Billing
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("amount")]
        public double Amount { get; set; }
    }
}
