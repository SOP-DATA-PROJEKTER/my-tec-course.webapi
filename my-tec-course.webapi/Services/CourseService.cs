using my_tec_course.webapi.Interfaces.Repositories;
<<<<<<< HEAD
=======
using my_tec_course.webapi.Interfaces.Services;
>>>>>>> parent of 6bfc996 (Revert "9 opret services")
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
<<<<<<< HEAD
    public class CourseService
=======
    public class CourseService: ICourseService
>>>>>>> parent of 6bfc996 (Revert "9 opret services")
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

<<<<<<< HEAD
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCourseAsync(int id)
=======
        public async Task<bool> DeleteAsync(int id)
>>>>>>> parent of 6bfc996 (Revert "9 opret services")
        {
            if(_courseRepository.GetByIdAsync(id) == null)
            {
                throw new KeyNotFoundException($"Course with ID: {id} not found.");
            }
            await _courseRepository.DeleteAsync(id);
            return true;
        }

<<<<<<< HEAD
        public Task<IEnumerable<Course>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
=======
        public async Task<IEnumerable<Course>> GetAllAsync()
>>>>>>> parent of 6bfc996 (Revert "9 opret services")
        {
            return await _courseRepository.GetAllAsync();
        }

<<<<<<< HEAD
        public Task<Course> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
=======

        public async Task<Course> GetByIdAsync(int id)
>>>>>>> parent of 6bfc996 (Revert "9 opret services")
        {
            return await _courseRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Course with ID {id} not found.");
        }

<<<<<<< HEAD
        public Task<Course> UpdateAsync(Course entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Course> UpdateCourseAsync(Course course)
=======

        public async Task<Course> UpdateAsync(Course course)
>>>>>>> parent of 6bfc996 (Revert "9 opret services")
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");
            }

            var existingCourse = await _courseRepository.GetByIdAsync(course.id)
                ?? throw new KeyNotFoundException($"Course with ID {course.id} not found.");
<<<<<<< HEAD
            return await _courseRepository.UpdateAsync(course);
        }


=======

            return await _courseRepository.UpdateAsync(course);
        }
>>>>>>> parent of 6bfc996 (Revert "9 opret services")
    }
}
