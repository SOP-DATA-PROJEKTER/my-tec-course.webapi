using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class CourseSubectRepository : ICourseSubjectRepository, ICrudMethods<CourseSubject>
    {
        private readonly ApplicationDbContext _context;
        public CourseSubectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CourseSubject> CreateAsync(CourseSubject entity)
        {
            await _context.CourseSubjects.AddAsync(entity);
            if(await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while creating the course subject");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.CourseSubjects.FindAsync(id) ?? throw new Exception("Course subject not found");
            _context.CourseSubjects.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CourseSubject>> GetAllAsync()
        {
            var result = await _context.CourseSubjects.ToListAsync();
            if (result.Count > 0)
                return result;
            else
                throw new Exception("No course subjects found");
        }

        public async Task<CourseSubject> GetByIdAsync(int id)
        {
            var result = await _context.CourseSubjects.FindAsync(id);
            return result ?? throw new Exception("Course subject not found");

        }

        public async Task<CourseSubject> UpdateAsync(CourseSubject entity)
        {
            _context.Update(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while updating the course subject");
        }
    }
}
