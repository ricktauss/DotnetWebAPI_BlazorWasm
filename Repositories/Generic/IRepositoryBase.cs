namespace Repositories.Generic
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();

        T? FindById(object entityId);
        Task<T?> FindByIdAsync(object entityId);

        T? Insert(T entity);
        Task<T?> InsertAsync(T entity);

        T? Update(object entityId, T entity);
        Task<T?> UpdateAsync(object entityId, T entity);

        void DeleteById(object entityId);
        Task DeleteByIdAsync(object entityId);

        void Delete(T entity);
        Task DeleteAsync(T entity);
    }
}
