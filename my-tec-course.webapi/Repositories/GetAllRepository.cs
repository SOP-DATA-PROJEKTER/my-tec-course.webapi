using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Repositories
{
    public class GetAllRepository : IGetAllRepository
    {
        private readonly ApplicationDbContext _context;

        public GetAllRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EducationType>> GetAllEducationTypes()
        {
            return await _context.Set<EducationType>()
                .Include(et => et.educations)
                    .ThenInclude(e => e.courses)
                        .ThenInclude(c => c.courseSubjects)
                            .ThenInclude(cs => cs.milestones)
                .Include(et => et.educations)
                    .ThenInclude(e => e.courses)
                        .ThenInclude(c => c.courseSubjects)
                            .ThenInclude(cs => cs.courseTasks)
                .ToListAsync();
        }
    }
}
