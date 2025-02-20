using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class PathwayRepository : IGenericCrudRepository<Pathway>
    {
        private readonly ApplicationDbContext _context;

        public PathwayRepository(ApplicationDbContext context)
        {
            _context = context;
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
