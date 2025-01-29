using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;

namespace my_tec_course.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSubjectController : ControllerBase
    {
        private readonly ICourseSubjectService _courseSubjectService;

        public CourseSubjectController(ICourseSubjectService courseSubjectService)
        {
            _courseSubjectService = courseSubjectService;
        }
    }
}
