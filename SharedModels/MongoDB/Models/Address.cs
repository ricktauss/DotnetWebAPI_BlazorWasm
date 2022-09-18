using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedLibrary.MongoDB.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Street { get; set; }
    }
}
