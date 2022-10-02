
namespace BlazorApiBackend.Services
{
    public interface IPersonService
    {
        IEnumerable<PersonDto> GetAll();

        Task<IEnumerable<PersonDto>> GetAllAsync();

        PersonDto? GetById(object personId);
        Task<PersonDto?> GetByIdAsync(object personId);

        bool TryGetById(object personId, out PersonDto? person);
        Task<Tuple<bool, PersonDto?>> TryGetByIdAsync(object personId);

        PersonDto? Insert(PersonDto person);
        Task<PersonDto?> InsertAsync(PersonDto person);

        PersonDto? Update(object personId, PersonDto person);
        Task<PersonDto?> UpdateAsync(object personId, PersonDto person);

        void Delete(object personId);
        Task DeleteAsync(object personId);
    }
}
