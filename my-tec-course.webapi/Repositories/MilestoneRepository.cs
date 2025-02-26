using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class MilestoneRepository : IBaseRepository<Milestone>
    {
        private readonly ApplicationDbContext _context;

        public MilestoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Milestone> CreateAsync(Milestone entity)
        {
            try
            {
                var subject = await _context.Subjects.FindAsync(entity.SubjectId) ?? throw new Exception("Subject not found");
                entity.Subject = subject;

                var milestone = await _context.Milestones.AddAsync(entity);

                await _context.SaveChangesAsync();
                return milestone.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Milestones.FindAsync(id);
            if (entity == null)
                return false;

            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Milestone>> GetAllAsync()
        {
            return await _context.Milestones.ToListAsync();

        }

        public async Task<IEnumerable<Milestone>> GetAllFromParentAsync(int parentId)
        {
            return await _context.Milestones.Where(x => x.SubjectId == parentId).ToListAsync();
        }

        public async Task<Milestone> GetByIdAsync(int id)
        {
            return await _context.Milestones.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Milestone> UpdateAsync(Milestone entity)
        {
            var storedEntity = await GetByIdAsync(entity.Id) ?? throw new Exception("Entity not found");
            var storedSubject = await _context.Subjects.FindAsync(entity.SubjectId) ?? throw new Exception("Subject not found");

            try
            {
                _context.Entry(storedEntity).CurrentValues.SetValues(entity);
                storedEntity.Subject = storedSubject;
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
