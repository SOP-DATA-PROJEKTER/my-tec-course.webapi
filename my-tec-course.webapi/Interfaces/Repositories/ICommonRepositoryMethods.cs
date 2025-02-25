namespace my_tec_course.webapi.Interfaces.Repositories
{
    public interface ICommonRepositoryMethods<T> where T : class
    {
        Task<IEnumerable<T>> GetAllFromParentAsync(int parentId);
    }
}
