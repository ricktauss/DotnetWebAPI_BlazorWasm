
namespace BlazorApiBackend.Repositories
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();

        T? FindById(string entityId);
        Task<T?> FindByIdAsync(string entityId);

        T? Insert(T entity);
        Task<T?> InsertAsync(T entity);

        T? Update(string entityId, T entity);
        Task<T?> UpdateAsync(string entityId, T entity);

        void DeleteById(string entityId);
        Task DeleteByIdAsync(string entityId);

        void Delete(T entity);
        Task DeleteAsync(T entity);
    }
}
