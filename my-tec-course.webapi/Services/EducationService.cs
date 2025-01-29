using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<Education> CreateAsync(Education entity)
        {
            // check validity of entity
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return await _educationRepository.CreateAsync(entity);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            // check if id is valid
            if(_educationRepository.GetByIdAsync(id) == null)
            {
                throw new KeyNotFoundException($"Education with ID: {id} not found.");
            }

            return await _educationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Education>> GetAllAsync()
        {
            return await _educationRepository.GetAllAsync();
        }

        public async Task<Education> GetByIdAsync(int id)
        {
            return await _educationRepository.GetByIdAsync(id);
        }

        public async Task<Education> UpdateAsync(Education entity)
        {
            // check validity of entity
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // check if entity exists
            if (_educationRepository.GetByIdAsync(entity.id) == null)
            {
                throw new KeyNotFoundException($"Education with ID: {entity.id} not found");
            }

            return await _educationRepository.UpdateAsync(entity);
        }
    }
}
