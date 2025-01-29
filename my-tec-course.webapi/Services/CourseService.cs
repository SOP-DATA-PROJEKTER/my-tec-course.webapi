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

        public async Task<Course> CreateAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");
            }

            if (string.IsNullOrEmpty(course.name))
            {
                throw new ArgumentException("Course name is required.");
            }

            return await _courseRepository.CreateAsync(course);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if(_courseRepository.GetByIdAsync(id) == null)
            {
                throw new KeyNotFoundException($"Course with ID: {id} not found.");
            }
            await _courseRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync();
        }


        public async Task<Course> GetByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Course with ID {id} not found.");
        }


        public async Task<Course> UpdateAsync(Course course)
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
