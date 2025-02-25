using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class EducationService : IGenericCrudService<Education>
    {
        private readonly IGenericCrudRepository<Education> _repository;

        public EducationService(IGenericCrudRepository<Education> repository)
        {
            _repository = repository;
        }

        public async Task<Education> CreateAsync(Education entity)
        {
            var result = await _repository.CreateAsync(entity);
            return result ?? throw new Exception("Failed to create education");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                throw new Exception("Failed to delete education");
            }
            return result;
        }

        public async Task<IEnumerable<Education>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result ?? throw new Exception("Failed to get all educations");
        }

        public async Task<Education> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result ?? throw new Exception("Failed to get education by id");
        }

        public async Task<Education> UpdateAsync(Education entity)
        {
            var result = await _repository.UpdateAsync(entity);
            return result ?? throw new Exception("Failed to update education");
        }
    }
}
