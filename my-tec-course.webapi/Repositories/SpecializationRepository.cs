using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class SpecializationRepository : IBaseRepository<Specialization>
    {

        private readonly ApplicationDbContext _context;

        public SpecializationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Specialization> CreateAsync(Specialization entity)
        {
            try
            {
                var result = await _context.Specializations.AddAsync(entity);
                if (await _context.SaveChangesAsync() > 0)
                    throw new Exception("Error creating Specialization");
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Specializations.FirstOrDefaultAsync(x => x.Id == id);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<IEnumerable<Specialization>> GetAllAsync()
        {
            var entities = await _context.Specializations.ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<Specialization>> GetAllFromParentAsync(int parentId)
        {
            return await _context.Specializations.Where(x => x.PathwayId == parentId).ToListAsync();
        }

        public Task<Specialization> GetByIdAsync(int id)
        {
            var entity = _context.Specializations.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<Specialization> UpdateAsync(Specialization entity)
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
