using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Services;

namespace my_tec_course.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationTypeController : ControllerBase
    {
        private readonly IEducationTypeService _educationTypeService;
        private readonly IGetAllService _getAllService;

        public EducationTypeController(IGetAllService getAllService, IEducationTypeService educationTypeService)
        {
            _getAllService = getAllService;
            _educationTypeService = educationTypeService;
        }

    }
}
