using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class SubjectService : IGenericCrudService<Subject>
    {
        private readonly IGenericCrudRepository<Subject> _repository;
        public SubjectService(IGenericCrudRepository<Subject> repository)
        {
            _repository = repository;
        }

        public async Task<Subject> CreateAsync(Subject entity)
        {
            var result = await _repository.CreateAsync(entity);
            return result ?? throw new Exception("Failed to create subject");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if(!result)
            {
                throw new Exception("Failed to delete subject");
            }
            return result;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result ?? throw new Exception("Failed to get subjects");
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result ?? throw new Exception("Failed to get subject");
        }

        public async Task<Subject> UpdateAsync(Subject entity)
        {
            var result = await _repository.UpdateAsync(entity);
            return result ?? throw new Exception("Failed to update subject");
        }
    }
}
