using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Interfaces.Repositories
{
    public interface IGetAllRepository
    {
        // get all educationtype and all subclasses
        Task<IEnumerable<EducationType>> GetAllEducationTypes();
    }
}
