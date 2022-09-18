using BlazorApiBackend.Repositories;
using WebApiBackend.Repositories;

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


        public Person? GetById(string entityId)
        {
            return _personRepository.FindById(entityId);
        }
        public Task<Person?> GetByIdAsync(string entityId)
        {
            return _personRepository.FindByIdAsync(entityId);
        }


        public bool TryGetById(string entityId, out Person? person)
        {
            person = GetById(entityId);

            return person != null;
        }
        public async Task<Tuple<bool, Person?>> TryGetByIdAsync(string entityId)
        {
            Person? _person = await GetByIdAsync(entityId);
            bool personFound = _person != null;

            return new Tuple<bool, Person?>(personFound,_person);
        }


        public Person? Insert(Person entity)
        {
            return _personRepository.Insert(entity);
        }
        public Task<Person?> InsertAsync(Person entity)
        {
            return _personRepository.InsertAsync(entity);
        }


        public Person? Update(string entityId, Person entity)
        {
            return _personRepository.Update(entityId, entity);
        }
        public Task<Person?> UpdateAsync(string entityId, Person entity)
        {
            return _personRepository.UpdateAsync(entityId, entity);
        }

        public void Delete(string entityId)
        {
            _personRepository.DeleteById(entityId);
        }
        public Task DeleteAsync(string entityId)
        {
            return _personRepository.DeleteByIdAsync(entityId);
        }

        #endregion
    }
}
