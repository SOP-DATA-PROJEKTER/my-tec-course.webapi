using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class SpecializationRepository : IGenericCrudRepository<Specialization>
    {

        private readonly ApplicationDbContext _context;

        public SpecializationRepository(ApplicationDbContext context)
        {
            _context = context;
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
