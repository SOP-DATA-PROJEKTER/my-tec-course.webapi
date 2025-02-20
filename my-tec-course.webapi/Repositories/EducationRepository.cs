using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class EducationRepository : IGenericCrudRepository<Education>
    {
        private readonly ApplicationDbContext _context;

        public EducationRepository(ApplicationDbContext context)
        {
            _context = context;
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
