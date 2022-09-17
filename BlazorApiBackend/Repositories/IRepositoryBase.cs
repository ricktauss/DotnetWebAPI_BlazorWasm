using SharedLibrary.Models;

namespace BlazorApiBackend.Repositories
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();
        T? FindById(int entityID);
        T? Insert(T entity);
        T? Update(T entity);
        void DeleteById(int entityID);
        Task DeleteByIdAsync(int entityID);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        void Save();
    }
}
