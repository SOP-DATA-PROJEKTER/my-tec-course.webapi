using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;
namespace my_tec_course.webapi.Services
{
    public class CourseService: ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");
            }

            if (string.IsNullOrEmpty(course.name))
            {
                throw new ArgumentException("Course name is required.");
            }

            var newCourse = new Course
            {
                name = course.name,
                courseType = course.courseType,
            };

            return await _courseRepository.CreateAsync(newCourse);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            if(_courseRepository.GetByIdAsync(id) == null)
            {
                throw new KeyNotFoundException($"Course with ID: {id} not found.");
            }
            await _courseRepository.DeleteAsync(id);
            return true;
        }


        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Course with ID {id} not found.");
        }


        public async Task<Course> UpdateCourseAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");
            }

            var existingCourse = await _courseRepository.GetByIdAsync(course.id)
                ?? throw new KeyNotFoundException($"Course with ID {course.id} not found.");
            return await _courseRepository.UpdateAsync(course);
        }
        
    }
}
