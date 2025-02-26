using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class SubjectRepository : IBaseRepository<Subject>
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Subject> CreateAsync(Subject entity)
        {
            try
            {
                var course = await _context.Courses.FindAsync(entity.CourseId) ?? throw new Exception("Course not found");
                entity.Course = course;

                var subject = await _context.Subjects.AddAsync(entity);

                await _context.SaveChangesAsync();
                return subject.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Subjects.FindAsync(id);
            if (entity == null)
                return false;

            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<IEnumerable<Subject>> GetAllFromParentAsync(int parentId)
        {
            return await _context.Subjects.Where(x => x.CourseId == parentId).ToListAsync();
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Subject> UpdateAsync(Subject entity)
        {
            var storedEntity = await GetByIdAsync(entity.Id) ?? throw new Exception("Entity not found");
            var storedCourse = await _context.Courses.FindAsync(entity.CourseId) ?? throw new Exception("Course not found");

            try
            {
                _context.Entry(storedEntity).CurrentValues.SetValues(entity);
                storedEntity.Course = storedCourse;
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
