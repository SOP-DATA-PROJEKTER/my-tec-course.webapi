using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class UserReflectionRepository : IUserReflectionRepository
    {
        private readonly ApplicationDbContext _context;
        public UserReflectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserReflection> CreateAsync(UserReflection entity)
        {
            await _context.UserReflections.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while creating the Milestone");
<<<<<<< HEAD
            // test
=======
>>>>>>> parent of 6bfc996 (Revert "9 opret services")
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.UserReflections.FindAsync(id) ?? throw new Exception("UserReflection not found");
            _context.UserReflections.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<UserReflection>> GetAllAsync()
        {
            var result = await _context.UserReflections.ToListAsync();
            if (result.Count > 0)
                return result;
            else
                throw new Exception("No UserReflection Found");
        }

        public async Task<UserReflection> GetByIdAsync(int id)
        {
            var result = await _context.UserReflections.FindAsync(id);
            return result ?? throw new Exception("UserReflection not found");

        }

        public async Task<UserReflection> UpdateAsync(UserReflection entity)
        {
            // overwrite old entity with new
            _context.Update(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                throw new Exception("An error occurred while updating the UserReflection");
        }
    }
}
