namespace my_tec_course.webapi.Interfaces.Services
{
    public interface ICommonServiceMethods<T> where T : class
    {
        Task<IEnumerable<T>> GetAllFromParentAsync(int parentId);
    }
}
