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
            IEnumerable<PersonDto> personsDto = _mapper.Map<IEnumerable<PersonDto>>(_personRepository.FindAll());

            return personsDto;
        }

        public Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            Task<IEnumerable<Person>> resultPersons = _personRepository.FindAllAsync();
            Task<IEnumerable<PersonDto>> resultPersonsDto = _mapper.Map<Task<IEnumerable<PersonDto>>>(resultPersons);

            return resultPersonsDto;
        }


        public PersonDto? GetById(string personId)
        {
            Person? resultPerson = _personRepository.FindById(personId);
            PersonDto? resultPersonDto = _mapper.Map<PersonDto?>(resultPerson);

            return resultPersonDto;
        }

        public Task<PersonDto?> GetByIdAsync(string personId)
        {
            Task<Person?> resultPerson = _personRepository.FindByIdAsync(personId);
            Task<PersonDto?> resultPersonDto = _mapper.Map<Task<PersonDto?>>(resultPerson);

            return resultPersonDto;
        }


        public bool TryGetById(string personId, out PersonDto? person)
        {
            person = GetById(personId);

            return person != null;
        }

        public async Task<Tuple<bool, PersonDto?>> TryGetByIdAsync(string personId)
        {
            PersonDto? resultPerson = await GetByIdAsync(personId);
            bool personFound = resultPerson != null;

            return new Tuple<bool, PersonDto?>(personFound, resultPerson);
        }


        public PersonDto? Insert(PersonDto personDto)
        {
            Person person = _mapper.Map<Person>(personDto);
            Person? resultPerson = _personRepository.Insert(person);
            PersonDto? resultPersonDto = _mapper.Map<PersonDto?>(resultPerson);

            return resultPersonDto;
        }

        public Task<PersonDto?> InsertAsync(PersonDto personDto)
        {
            Person person = _mapper.Map<Person>(personDto);
            Task<Person?> resultPerson = _personRepository.InsertAsync(person);
            Task<PersonDto?> resultPersonDto = _mapper.Map<Task<PersonDto?>>(resultPerson);

            return resultPersonDto;
        }


        public PersonDto? Update(string personId, PersonDto personDto)
        {
            Person person = _mapper.Map<Person>(personDto);
            Person? resultPerson = _personRepository.Update(personId, person);
            PersonDto? resultPersonDto = _mapper.Map<PersonDto?>(resultPerson);

            return resultPersonDto;
        }

        public Task<PersonDto?> UpdateAsync(string personId, PersonDto personDto)
        {
            Person person = _mapper.Map<Person>(personDto);
            Task<Person?> resultPerson = _personRepository.UpdateAsync(personId, person);
            Task<PersonDto?> resultPersonDto = _mapper.Map<Task<PersonDto?>>(resultPerson);

            return resultPersonDto;
        }

        public void Delete(string personId)
        {
            _personRepository.DeleteById(personId);
        }

        public Task DeleteAsync(string personId)
        {
            return _personRepository.DeleteByIdAsync(personId);
        }

        #endregion
    }
}
