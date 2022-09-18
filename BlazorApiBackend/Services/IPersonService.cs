using SharedLibrary.Models;

namespace BlazorApiBackend.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();

        Task<IEnumerable<Person>> GetAllAsync();

        Person? GetById(int personID);
        Task<Person?> GetByIdAsync(int personID);

        bool TryGetById(int personID, out Person? person);
        Task<Tuple<bool, Person?>> TryGetByIdAsync(int personID);

        Person? Insert(Person person);
        Task<Person?> InsertAsync(Person person);

        Person? Update(Person person);
        Task<Person?> UpdateAsync(Person person);

        void Delete(int personID);
        Task DeleteAsync(int personID);
    }
}
