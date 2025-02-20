using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class PathwayService : IGenericCrudService<Pathway>
    {
        private readonly IGenericCrudRepository<Pathway> _repository;
        public PathwayService(IGenericCrudRepository<Pathway> repository)
        {
            _repository = repository;
        }

        public Task<Pathway> CreateAsync(Pathway entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pathway>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pathway> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pathway> UpdateAsync(Pathway entity)
        {
            throw new NotImplementedException();
        }
    }
}
