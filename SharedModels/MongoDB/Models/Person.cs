using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedLibrary.MongoDB.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? EMail { get; set; }
        public string? Phone { get; set; }
        public Address? Address { get; set; }

    }
}