using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class EducationTypeService : IEducationTypeService
    {
        private readonly IEducationTypeRepository _educationTypeRepository;

        public EducationTypeService(IEducationTypeRepository educationTypeRepository)
        {
            _educationTypeRepository = educationTypeRepository;
        }

        public async Task<EducationType> CreateAsync(EducationType entity)
        {
            // check if the entity is null
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return await _educationTypeRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // check if entity with id exist
            if(await GetByIdAsync(id) == null)
            {
                throw new Exception("Entity not found");
            }

            return await _educationTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EducationType>> GetAllAsync()
        {
            return await _educationTypeRepository.GetAllAsync();
        }

        public async Task<EducationType> GetByIdAsync(int id)
        {
            return await _educationTypeRepository.GetByIdAsync(id);
        }

        public async Task<EducationType> UpdateAsync(EducationType entity)
        {
            // check if the entity is null
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // check if entity with id exist
            if (await GetByIdAsync(entity.id) == null)
            {
                throw new Exception("Entity not found");
            }

            return await _educationTypeRepository.UpdateAsync(entity);
        }
    }
}
