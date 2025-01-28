using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class MilestoneRepository : IMilestoneRepository, ICrudMethods<Milestone>
    {
        private readonly ApplicationDbContext _context;
        public MilestoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Milestone> CreateAsync(Milestone entity)
        {
            await _context.Milestones.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while creating the Milestone");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Milestones.FindAsync(id) ?? throw new Exception("Milestone not found");
            _context.Milestones.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Milestone>> GetAllAsync()
        {
            var result = await _context.Milestones.ToListAsync();
            if (result.Count > 0)
                return result;
            else
                throw new Exception("No Milestone Found");
        }

        public async Task<Milestone> GetByIdAsync(int id)
        {
            var result = await _context.Milestones.FindAsync(id);
            return result ?? throw new Exception("Milestone not found");

        }

        public async Task<Milestone> UpdateAsync(Milestone entity)
        {
            // overwrite old entity with new
            _context.Update(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while updating the Milestone");
        }
    }
}
