using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class CourseService : IBaseService<Course>
    {
        private readonly IBaseRepository<Course> _repository;
        public CourseService(IBaseRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<Course> CreateAsync(Course entity)
        {
            var result = await _repository.CreateAsync(entity);
            return result ?? throw new Exception("Course not created");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                throw new Exception("Course not deleted");
            }
            return result;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result ?? throw new Exception("Courses not found");
        }

        public async Task<IEnumerable<Course>> GetAllFromParentAsync(int parentId)
        {
            var result = await _repository.GetAllFromParentAsync(parentId);
            return result ?? throw new Exception("Courses not found");
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result ?? throw new Exception("Course not found");
        }

        public async Task<Course> UpdateAsync(Course entity)
        {
            var result = await _repository.UpdateAsync(entity);
            return result ?? throw new Exception("Course not updated");
        }
    }
}
