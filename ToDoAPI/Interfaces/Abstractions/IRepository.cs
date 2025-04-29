namespace ToDoAPI.Interfaces.Abstractions;


public interface IRepository<T, R> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync(int? offset = null, int? skip = null);
    Task<T?> GetByIdAsync(R id);
    Task<R> AddAsync(T entity);
    Task<R> UpdateAsync(T entity);
    Task<R> DeleteAsync(R id);
}