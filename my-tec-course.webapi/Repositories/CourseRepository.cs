using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Course> CreateAsync(Course entity)
        {
            _context.Courses.Add(entity);
            if(await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while creating the course");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Courses.FindAsync(id) ?? throw new Exception("Course not found");
            _context.Courses.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var result = await _context.Courses.ToListAsync();
            if (result.Count > 0)
                return result;
            else
                throw new Exception("No course subjects found");
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var result = await _context.Courses.FindAsync(id);
            return result ?? throw new Exception("Course not found");
        }

        public async Task<Course> UpdateAsync(Course entity)
        {
            _context.Update(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while updating the course");
        }
    }
}
