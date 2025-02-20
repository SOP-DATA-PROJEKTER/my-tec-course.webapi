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

        public Task<Education> CreateAsync(Education entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Education>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Education> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Education> UpdateAsync(Education entity)
        {
            throw new NotImplementedException();
        }
    }
}
