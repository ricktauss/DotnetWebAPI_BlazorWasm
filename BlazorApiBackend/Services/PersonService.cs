using AutoMapper;
using BlazorApiBackend.Repositories;
using SharedLibrary.DTOs;

namespace BlazorApiBackend.Services
{
    public class PersonService : IPersonService
    {
        #region fields

        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        #endregion

        #region constructor

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        #endregion

        #region methods

        public IEnumerable<PersonDto> GetAll()
        {
            IEnumerable<PersonDto> resultPersonsDto = _mapper.Map<IEnumerable<PersonDto>>(_personRepository.FindAll());

            return resultPersonsDto;
        }

        public Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            Task<IEnumerable<Person>> resultPersons = _personRepository.FindAllAsync();
            Task<IEnumerable<PersonDto>> resultPersonsDto = _mapper.Map<Task<IEnumerable<PersonDto>>>(resultPersons);

            return resultPersonsDto;
        }


        public PersonDto? GetById(object personId)
        {
            Person? resultPerson = _personRepository.FindById(personId);
            PersonDto? resultPersonDto = _mapper.Map<PersonDto?>(resultPerson);

            return resultPersonDto;
        }

        public Task<PersonDto?> GetByIdAsync(object personId)
        {
            Task<Person?> resultPerson = _personRepository.FindByIdAsync(personId);
            Task<PersonDto?> resultPersonDto = _mapper.Map<Task<PersonDto?>>(resultPerson);

            return resultPersonDto;
        }


        public bool TryGetById(object personId, out PersonDto? person)
        {
            person = GetById(personId);

            return person != null;
        }

        public async Task<Tuple<bool, PersonDto?>> TryGetByIdAsync(object personId)
        {
            PersonDto? resultPerson = await GetByIdAsync(personId);
            bool personFound = resultPerson != null;

            return new Tuple<bool, PersonDto?>(personFound, resultPerson);
        }


        public PersonDto? Insert(PersonDto person)
        {
            Person personToInsert = _mapper.Map<Person>(person);
            Person? resultPerson = _personRepository.Insert(personToInsert);
            PersonDto? resultPersonDto = _mapper.Map<PersonDto?>(resultPerson);

            return resultPersonDto;
        }

        public Task<PersonDto?> InsertAsync(PersonDto person)
        {
            Person personToInsert = _mapper.Map<Person>(person);
            Task<Person?> resultPerson = _personRepository.InsertAsync(personToInsert);
            Task<PersonDto?> resultPersonDto = _mapper.Map<Task<PersonDto?>>(resultPerson);

            return resultPersonDto;
        }


        public PersonDto? Update(object personId, PersonDto person)
        {
            Person personToUpdate = _mapper.Map<Person>(person);
            Person? resultPerson = _personRepository.Update(personId, personToUpdate);
            PersonDto? resultPersonDto = _mapper.Map<PersonDto?>(resultPerson);

            return resultPersonDto;
        }

        public Task<PersonDto?> UpdateAsync(object personId, PersonDto person)
        {
            Person personToUpdate = _mapper.Map<Person>(person);
            Task<Person?> resultPerson = _personRepository.UpdateAsync(personId, personToUpdate);
            Task<PersonDto?> resultPersonDto = _mapper.Map<Task<PersonDto?>>(resultPerson);

            return resultPersonDto;
        }

        public void Delete(object personId)
        {
            _personRepository.DeleteById(personId);
        }

        public Task DeleteAsync(object personId)
        {
            return _personRepository.DeleteByIdAsync(personId);
        }

        #endregion
    }
}
