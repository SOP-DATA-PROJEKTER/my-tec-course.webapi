using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class SubjectRepository : IGenericCrudService<Subject>
    {
        private readonly IGenericCrudRepository<Subject> _repository;
        public SubjectRepository(IGenericCrudRepository<Subject> repository)
        {
            _repository = repository;
        }

        public Task<Subject> CreateAsync(Subject entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Subject>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Subject> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> UpdateAsync(Subject entity)
        {
            throw new NotImplementedException();
        }
    }
}
