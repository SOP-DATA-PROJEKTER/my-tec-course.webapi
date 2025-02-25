using Microsoft.EntityFrameworkCore;
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

        public async Task<Education> CreateAsync(Education entity)
        {
            try
            {
                var result = await _context.Educations.AddAsync(entity);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Educations.FindAsync(id);
            if(entity == null)
                return false;

            _context.Educations.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Education>> GetAllAsync()
        {
            return await _context.Educations
                .Include(p => p.Pathways)
                .ThenInclude(s => s.Specializations)
                .ThenInclude(c => c.Courses)
                .ThenInclude(s => s.Subjects)
                .ThenInclude(m => m.Milestones)
                .ToListAsync();
        }

        public async Task<Education> GetByIdAsync(int id)
        {
            return await _context.Educations
                .Include(p => p.Pathways)
                .ThenInclude(s => s.Specializations)
                .ThenInclude(c => c.Courses)
                .ThenInclude(s => s.Subjects)
                .ThenInclude(m => m.Milestones)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Education> UpdateAsync(Education entity)
        {
            var storedEntity = await GetByIdAsync(entity.Id) ?? throw new Exception("Entity not found");

            try
            {
                _context.Entry(storedEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return storedEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
