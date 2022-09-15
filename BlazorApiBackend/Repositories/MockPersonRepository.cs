using SharedLibrary.Models;
using System.Diagnostics;

namespace BlazorApiBackend.Repositories
{
    public class MockPersonRepository : IPersonRepository
    {
        private List<Person> _persons;

        public MockPersonRepository()
        {
            _persons = new List<Person> {
                new Person { PersonID = 1, FirstName = "John", LastName = "Doe", Gender = "Male", Age = 50, EMail="john.doe@example.com", Phone="+01 123456",
                    Address = new Address{ City = "Graz", PostalCode="8010", Street="Lendstraße 1" }
                },
                new Person { PersonID = 2, FirstName = "Susi", LastName = "Doe", Gender = "Female", Age = 35, EMail="susi.doe@example.com", Phone="+01 778899",
                    Address = new Address{ City = "Graz", PostalCode="8010", Street="Lendstraße 1" }
                },
                new Person { PersonID = 3, FirstName = "Max", LastName = "Mustermann", Gender = "Male", Age = 38, EMail="max.mustermann@example.com", Phone="+01 11223344",
                    Address = new Address{ City = "Vienna", PostalCode="1010", Street="Lasallstraße 1" }
                }
            };
        }


        public IEnumerable<Person> FindAll()
        {
            return _persons;
        }

        public Person? FindById(int personID) => _persons.FirstOrDefault(p => p.PersonID == personID);


        public Person? Insert(Person person)
        {
            int maxPersonID = _persons.Max(p => p.PersonID);
            person.PersonID = maxPersonID + 1;
            _persons.Add(person);

            return person;
        }

        public Person? Update(Person person)
        {
            Person? _person = FindById(person.PersonID);
            if (_person != null)
            {
                DeleteById(person.PersonID);
                Insert(person);
                return person;
            }

            return null;
        }


        public void Delete(Person entity)
        {
            _persons.Remove(entity);
        }

        public void DeleteById(int personID)
        {
            Person? person = FindById(personID);

            if (person != null) { _persons.Remove(person); }
        }

 
        public void Save()
        {
            ///
        }
    }
}
