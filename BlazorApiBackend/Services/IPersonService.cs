
namespace BlazorApiBackend.Services
{
    public interface IPersonService
    {
        IEnumerable<PersonDto> GetAll();

        Task<IEnumerable<PersonDto>> GetAllAsync();

        PersonDto? GetById(string entityId);
        Task<PersonDto?> GetByIdAsync(string entityId);

        bool TryGetById(string entityId, out PersonDto? entity);
        Task<Tuple<bool, PersonDto?>> TryGetByIdAsync(string entityId);

        PersonDto? Insert(PersonDto entity);
        Task<PersonDto?> InsertAsync(PersonDto entity);

        PersonDto? Update(string entityId, PersonDto entity);
        Task<PersonDto?> UpdateAsync(string entityId, PersonDto entity);

        void Delete(string entityId);
        Task DeleteAsync(string entityId);
    }
}
