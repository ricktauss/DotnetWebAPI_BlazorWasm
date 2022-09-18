
namespace BlazorApiBackend.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();

        Task<IEnumerable<Person>> GetAllAsync();

        Person? GetById(string entityId);
        Task<Person?> GetByIdAsync(string entityId);

        bool TryGetById(string entityId, out Person? entity);
        Task<Tuple<bool, Person?>> TryGetByIdAsync(string entityId);

        Person? Insert(Person entity);
        Task<Person?> InsertAsync(Person entity);

        Person? Update(string entityId, Person entity);
        Task<Person?> UpdateAsync(string entityId, Person entity);

        void Delete(string entityId);
        Task DeleteAsync(string entityId);
    }
}
