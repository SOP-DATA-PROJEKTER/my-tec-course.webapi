namespace my_tec_course.webapi.Interfaces.Repositories
{
    public interface IBaseRepository<T> : ICommonRepositoryMethods<T>, IGenericCrudRepository<T> where T : class
    {
    }
}
