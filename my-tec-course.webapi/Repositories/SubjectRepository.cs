using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class SubjectRepository : IGenericCrudRepository<Subject>
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
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
