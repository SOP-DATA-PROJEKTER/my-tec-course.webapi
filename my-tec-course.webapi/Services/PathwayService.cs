using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class PathwayService : IBaseService<Pathway>
    {
        private readonly IBaseRepository<Pathway> _repository;
        public PathwayService(IBaseRepository<Pathway> repository)
        {
            _repository = repository;
        }

        public async Task<Pathway> CreateAsync(Pathway entity)
        {
            var result = await _repository.CreateAsync(entity);
            return result ?? throw new Exception("Pathway could not be created");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if(!result) throw new Exception("Pathway could not be deleted");
            return result;
        }

        public async Task<IEnumerable<Pathway>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result ?? throw new Exception("No Pathways found");
        }

        public async Task<IEnumerable<Pathway>> GetAllFromParentAsync(int parentId)
        {
            var result = await _repository.GetAllFromParentAsync(parentId);
            return result ?? throw new Exception("No Pathways found");
        }

        public async Task<Pathway> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result ?? throw new Exception("Pathway not found");
        }

        public async Task<Pathway> UpdateAsync(Pathway entity)
        {
            var result = await _repository.UpdateAsync(entity);
            return result ?? throw new Exception("Pathway could not be updated");
        }
    }
}
