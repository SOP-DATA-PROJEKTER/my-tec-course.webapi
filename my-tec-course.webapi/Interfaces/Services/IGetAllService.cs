using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Interfaces.Services
{
    public interface IGetAllService
    {
        // get all educationtype and all subclasses
        Task<IEnumerable<EducationType>> GetAllEducationTypes();
    }
}
