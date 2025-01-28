using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class EducationTypeRepository : IEducationTypeRepository, ICrudMethods<EducationType>
    {
        private readonly ApplicationDbContext _context;
        public EducationTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<EducationType> CreateAsync(EducationType entity)
        {
            await _context.EducationTypes.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while creating the EducationType");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.EducationTypes.FindAsync(id) ?? throw new Exception("EducationType not found");
            _context.EducationTypes.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<EducationType>> GetAllAsync()
        {
            var result = await _context.EducationTypes.ToListAsync();
            if (result.Count > 0)
                return result;
            else
                throw new Exception("No EducationType Found");
        }

        public async Task<EducationType> GetByIdAsync(int id)
        {
            var result = await _context.EducationTypes.FindAsync(id);
            return result ?? throw new Exception("EducationType not found");

        }

        public async Task<EducationType> UpdateAsync(EducationType entity)
        {
            // overwrite old entity with new
            _context.Update(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while updating the EducationType");
        }
    }
}
