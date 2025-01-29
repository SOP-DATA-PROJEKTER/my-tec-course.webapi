using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Services
{
    public class GetAllService : IGetAllService
    {
        private readonly IGetAllRepository _getAllRepository;

        public GetAllService(IGetAllRepository getAllRepository)
        {
            _getAllRepository = getAllRepository;
        }

        public async Task<IEnumerable<EducationType>> GetAllEducationTypes()
        {
            return await _getAllRepository.GetAllEducationTypes() ?? throw new Exception("No data found");
        }
    }
}
