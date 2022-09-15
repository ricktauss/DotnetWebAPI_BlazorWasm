using SharedLibrary.Models;

namespace BlazorApiBackend.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person? GetById(int personID);
        bool TryGetById(int personID, out Person? person);
        Person? Insert(Person person);
        Person? Update(Person person);
        void Delete(int personID);
    }
}
