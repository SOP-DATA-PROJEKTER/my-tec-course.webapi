using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class MilestoneService : IBaseService<Milestone>
    {
        private readonly IBaseRepository<Milestone> _repository;

        public MilestoneService(IBaseRepository<Milestone> repository)
        {
            _repository = repository;
        }

        public async Task<Milestone> CreateAsync(Milestone entity)
        {
            var result = await _repository.CreateAsync(entity);
            return result ?? throw new Exception("Failed to create milestone");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if(!result)
            {
                throw new Exception("Failed to delete milestone");
            }
            return result;
        }

        public async Task<IEnumerable<Milestone>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result ?? throw new Exception("Failed to get milestones");
        }

        public async Task<IEnumerable<Milestone>> GetAllFromParentAsync(int parentId)
        {
            var result = await _repository.GetAllFromParentAsync(parentId);
            return result ?? throw new Exception("Failed to get milestones");
        }

        public async Task<Milestone> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result ?? throw new Exception("Failed to get milestone");
        }

        public async Task<Milestone> UpdateAsync(Milestone entity)
        {
            var result = await _repository.UpdateAsync(entity);
            return result ?? throw new Exception("Failed to update milestone");
        }
    }
}
