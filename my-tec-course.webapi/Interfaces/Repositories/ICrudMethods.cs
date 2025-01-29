namespace my_tec_course.webapi.Interfaces.Repositories
{
    public interface ICrudMethods<T> where T : class
    {
        // Async CRUD Methods For Repositories
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
