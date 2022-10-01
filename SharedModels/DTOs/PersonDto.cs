using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace SharedLibrary.DTOs
{
    public class PersonDto
    {
        [ReadOnly(true)]
        public string? Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? EMail { get; set; }
        public string? Phone { get; set; }

    }
}