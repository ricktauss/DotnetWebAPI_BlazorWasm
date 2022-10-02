using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using BlazorApiBackend.Repositories;

namespace WebApiBackend.Repositories
{
    public class MockPersonRepository : IPersonRepository
    {
        #region fields

        private List<Person> _persons;

        #endregion

        #region constructor

        public MockPersonRepository()
        {
            _persons = new List<Person> {
                new Person { Id = Guid.NewGuid().ToString(), FirstName = "John", LastName = "Doe", Gender = "Male", Age = 50, EMail="john.doe@example.com", Phone="+01 123456",
                    Address = new Address{ City = "Graz", PostalCode="8010", Street="Lendstraße 1" }
                },
                new Person { Id = Guid.NewGuid().ToString(), FirstName = "Susi", LastName = "Doe", Gender = "Female", Age = 35, EMail="susi.doe@example.com", Phone="+01 778899",
                    Address = new Address{ City = "Graz", PostalCode="8010", Street="Lendstraße 1" }
                },
                new Person { Id = Guid.NewGuid().ToString(), FirstName = "Max", LastName = "Mustermann", Gender = "Male", Age = 38, EMail="max.mustermann@example.com", Phone="+01 11223344",
                    Address = new Address{ City = "Vienna", PostalCode="1010", Street="Lasallstraße 1" }
                }
            };
        }

        #endregion

        #region methods

        public IEnumerable<Person> FindAll()
        {
            return _persons;
        }
        public async Task<IEnumerable<Person>> FindAllAsync() => await Task.FromResult(FindAll());

        public Person? FindById(object entityId) => _persons.FirstOrDefault(p => entityId.Equals(p.Id));
        public async Task<Person?> FindByIdAsync(object entityId) => await Task.FromResult(FindById(entityId));

        public Person? Insert(Person entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            _persons.Add(entity);

            return entity;
        }
        public async Task<Person?> InsertAsync(Person entity) => await Task.FromResult(Insert(entity));

        public Person? Update(object entityId, Person entity)
        {
            Person? person = FindById(entityId);
            if (person != null)
            {
                DeleteById(entityId);
                Insert(entity);
                return entity;
            }

            return null;
        }
        public async Task<Person?> UpdateAsync(object entityId, Person entity) => await Task.FromResult(Update(entityId, entity));

        public void Delete(Person entity)
        {
            _persons.Remove(entity);
        }
        public async Task DeleteAsync(Person entity) => await Task.Run(() => _persons.Remove(entity));

        public void DeleteById(object entityId)
        {
            Person? person = FindById(entityId);

            if (person != null) { _persons.Remove(person); }
        }
        public async Task DeleteByIdAsync(object entityId) => await Task.Run(() => DeleteById(entityId));

        #endregion
    }
}
