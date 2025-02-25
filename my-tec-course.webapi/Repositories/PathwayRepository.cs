using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class PathwayRepository : IBaseRepository<Pathway>
    {
        private readonly ApplicationDbContext _context;

        public PathwayRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pathway> CreateAsync(Pathway entity)
        {
            try
            {
                var education = await _context.Educations.FindAsync(entity.EducationId) ?? throw new Exception("Education not found");
                entity.Education = education;

                var pathway = await _context.Pathways.AddAsync(entity);

                await _context.SaveChangesAsync();
                return pathway.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Pathways.FindAsync(id);
            if(entity == null)
                return false;

            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Pathway>> GetAllAsync()
        {
            return await _context.Pathways.ToListAsync();
        }

        public async Task<IEnumerable<Pathway>> GetAllFromParentAsync(int parentId)
        {
            return await _context.Pathways.Where(x => x.EducationId == parentId).ToListAsync();
        }

        public async Task<Pathway> GetByIdAsync(int id)
        {
            return await _context.Pathways.FindAsync(id);
        }

        public async Task<Pathway> UpdateAsync(Pathway entity)
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
