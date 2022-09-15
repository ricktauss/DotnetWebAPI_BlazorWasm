namespace SharedLibrary.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? EMail { get; set; }
        public string? Phone { get; set; }
        public Address? Address { get; set; }

    }
}