using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly ApplicationDbContext _context;
        public EducationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Education> CreateAsync(Education entity)
        {
            await _context.Educations.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while creating the course subject");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Educations.FindAsync(id) ?? throw new Exception("Education not found");
            _context.Educations.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Education>> GetAllAsync()
        {
            var result = await _context.Educations.ToListAsync();
            if (result.Count > 0)
                return result;
            else
                throw new Exception("No education found");
        }
        public async Task<Education> GetByIdAsync(int id)
        {
            var result = await _context.Educations.FindAsync(id);
            return result ?? throw new Exception("Education not found");

        }
        public async Task<Education> UpdateAsync(Education entity)
        {
            // overwrite old entity with new
            _context.Update(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while updating the Education");
        }
    }
}
