using BlazorApiBackend.Repositories;
using SharedLibrary.Models;

namespace BlazorApiBackend.Services
{
    public class PersonService:IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<Person> GetAll()
        {
            return _personRepository.FindAll();
        }

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            return _personRepository.FindAllAsync();
        }

        public Person? GetById(int personID)
        {
            return _personRepository.FindById(personID);
        }

        public bool TryGetById(int personID, out Person? person)
        {
            person = GetById(personID);

            return person != null;
        }

        public Person? Insert(Person person)
        {
            return _personRepository.Insert(person);
        }

        public Person? Update(Person person)
        {
            return _personRepository.Update(person);
        }

        public void Delete(int personID)
        {
            _personRepository.DeleteById(personID);
        }

        public Task DeleteAsync(int personID)
        {
            return _personRepository.DeleteByIdAsync(personID);
        }
    }
}
