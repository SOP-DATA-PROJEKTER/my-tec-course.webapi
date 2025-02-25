namespace my_tec_course.webapi.Interfaces.Services
{
    public interface IBaseService<T> : ICommonServiceMethods<T>, IGenericCrudService<T> where T : class
    {
    }
}
