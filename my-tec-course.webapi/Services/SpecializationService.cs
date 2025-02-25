using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class SpecializationService : IGenericCrudService<Specialization>
    {
        private readonly IGenericCrudRepository<Specialization> _repository;
        public SpecializationService(IGenericCrudRepository<Specialization> repository)
        {
            _repository = repository;
        }

        public async Task<Specialization> CreateAsync(Specialization entity)
        {
            var result = await _repository.CreateAsync(entity);
            return result ?? throw new Exception("Failed to create Specialization");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                throw new Exception("Failed to delete Specialization");
            }
            return result;
        }

        public Task<IEnumerable<Specialization>> GetAllAsync()
        {
            var result = _repository.GetAllAsync();
            return result ?? throw new Exception("Failed to get Specializations");
        }

        public async Task<Specialization> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result ?? throw new Exception("Failed to get Specialization");
        }

        public async Task<Specialization> UpdateAsync(Specialization entity)
        {
            var result = await _repository.UpdateAsync(entity);
            return result ?? throw new Exception("Failed to update Specialization");
        }
    }
}
