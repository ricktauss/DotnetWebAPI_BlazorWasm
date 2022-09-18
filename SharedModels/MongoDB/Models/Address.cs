using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedLibrary.MongoDB.Models
{
    public class Address
    {
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Street { get; set; }
    }
}
