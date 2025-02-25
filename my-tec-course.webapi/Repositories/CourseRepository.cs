using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class CourseRepository : IBaseRepository<Course>
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Course> CreateAsync(Course entity)
        {
            try
            {
                var specialization = await _context.Specializations.FindAsync(entity.SpecializationId) ?? throw new Exception("Specialization not found");
                entity.Specialization = specialization;

                var course = await _context.Courses.AddAsync(entity);

                await _context.SaveChangesAsync();
                return course.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Courses.FindAsync(id);
            if (entity == null)
                return false;

            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();

        }

        public async Task<IEnumerable<Course>> GetAllFromParentAsync(int parentId)
        {
            return await _context.Courses.Where(x => x.SpecializationId == parentId).ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Course> UpdateAsync(Course entity)
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
