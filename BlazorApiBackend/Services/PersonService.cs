using BlazorApiBackend.Repositories;
using SharedLibrary.Models;

namespace BlazorApiBackend.Services
{
    public class PersonService : IPersonService
    {
        #region fields

        private readonly IPersonRepository _personRepository;

        #endregion

        #region constructor

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        
        #endregion

        #region methods

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
        public Task<Person?> GetByIdAsync(int personID)
        {
            return _personRepository.FindByIdAsync(personID);
        }


        public bool TryGetById(int personID, out Person? person)
        {
            person = GetById(personID);

            return person != null;
        }
        public async Task<Tuple<bool, Person?>> TryGetByIdAsync(int personID)
        {
            Person? person = await GetByIdAsync(personID);
            bool personFound = person != null;

            return new Tuple<bool, Person?>(personFound,person);
        }


        public Person? Insert(Person person)
        {
            return _personRepository.Insert(person);
        }
        public Task<Person?> InsertAsync(Person person)
        {
            return _personRepository.InsertAsync(person);
        }


        public Person? Update(Person person)
        {
            return _personRepository.Update(person);
        }
        public Task<Person?> UpdateAsync(Person person)
        {
            return _personRepository.UpdateAsync(person);
        }

        public void Delete(int personID)
        {
            _personRepository.DeleteById(personID);
        }
        public Task DeleteAsync(int personID)
        {
            return _personRepository.DeleteByIdAsync(personID);
        }

        #endregion
    }
}
