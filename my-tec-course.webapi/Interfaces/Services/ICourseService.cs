using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Interfaces.Services
{
<<<<<<< HEAD
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(int id, Course course);
        Task<bool> DeleteCourseAsync(int id);
=======
    public interface ICourseService : IGenericCrudService<Course>
    {
>>>>>>> parent of 6bfc996 (Revert "9 opret services")
    }
}
