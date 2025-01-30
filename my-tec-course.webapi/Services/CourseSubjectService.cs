using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class CourseSubjectService : ICourseSubjectService
    {
        private readonly ICourseSubjectRepository _courseSubjectRepository;

        public CourseSubjectService(ICourseSubjectRepository courseSubjectRepository)
        {
            _courseSubjectRepository = courseSubjectRepository;
        }
        public async Task<CourseSubject> CreateAsync(CourseSubject entity)
        {
            // check validity of entity
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "CourseSubject cannot be null.");
            }

            var newCourseSubject = new CourseSubject
            {
                name = entity.name,
                teacherName = entity.teacherName,
                duration = entity.duration,
                roomName = entity.roomName
            };

            return await _courseSubjectRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // check validity of id
            if (_courseSubjectRepository.GetByIdAsync(id) == null)
            {
                throw new KeyNotFoundException($"CourseSubject with ID: {id} not found.");
            }

            return await _courseSubjectRepository.DeleteAsync(id);
        }

        public async Task<CourseSubject> GetByIdAsync(int id)
        {
            // check validity of id
            if(_courseSubjectRepository.GetByIdAsync(id) == null)
            {
                throw new KeyNotFoundException($"CourseSubject with ID: {id} not found.");
            }
            return await _courseSubjectRepository.GetByIdAsync(id);
        }

        public async Task<CourseSubject> UpdateAsync(CourseSubject entity)
        {
            // check validity of entity
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "CourseSubject cannot be null.");
            }

            // check if entity exists
            if (_courseSubjectRepository.GetByIdAsync(entity.id) == null)
            {
                throw new KeyNotFoundException($"CourseSubject with ID: {entity.id} not found.");
            }

            return await _courseSubjectRepository.UpdateAsync(entity);
        }


        public async Task<IEnumerable<CourseSubject>> GetAllAsync()
        {
            return await _courseSubjectRepository.GetAllAsync();
        }
    }
}
