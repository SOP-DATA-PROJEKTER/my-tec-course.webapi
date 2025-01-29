using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class MilestoneService : IMilestoneService
    {
        private readonly IMilestoneRepository _milestoneRepository;

        public MilestoneService(IMilestoneRepository milestoneRepository)
        {
            _milestoneRepository = milestoneRepository;
        }

        public async Task<Milestone> CreateAsync(Milestone entity)
        {
            // check if the entity is valid
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return await _milestoneRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // check if entity with id exist
            if(await _milestoneRepository.GetByIdAsync(id) == null)
            {
                throw new Exception("Entity not found");
            }

            return await _milestoneRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Milestone>> GetAllAsync()
        {
            return await _milestoneRepository.GetAllAsync();
        }

        public async Task<Milestone> GetByIdAsync(int id)
        {
            return await _milestoneRepository.GetByIdAsync(id);
        }

        public async Task<Milestone> UpdateAsync(Milestone entity)
        {
            // check if the entity is valid
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // check if entity with id exist
            if (await _milestoneRepository.GetByIdAsync(entity.id) == null)
            {
                throw new Exception("Entity not found");
            }

            return await _milestoneRepository.UpdateAsync(entity);
        }
    }
}
