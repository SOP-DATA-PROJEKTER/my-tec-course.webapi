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

        public Task<Specialization> CreateAsync(Specialization entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Specialization>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Specialization> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Specialization> UpdateAsync(Specialization entity)
        {
            throw new NotImplementedException();
        }
    }
}
