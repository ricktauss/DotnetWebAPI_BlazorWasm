using SharedLibrary.Models;

namespace BlazorApiBackend.Repositories
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        T? FindById(int entityID);
        T? Insert(T entity);
        T? Update(T entity);
        void DeleteById(int entityID);
        void Delete(T entity);
        void Save();
    }
}
