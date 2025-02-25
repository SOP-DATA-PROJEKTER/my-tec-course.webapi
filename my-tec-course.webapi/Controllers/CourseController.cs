using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;
using my_tec_course.webapi.Services;

namespace my_tec_course.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly IBaseService<Course> _courseService;
        private readonly IBaseService<Specialization> _specializationService;

        public CourseController(IBaseService<Course> courseService, IBaseService<Specialization> specializationService)
        {
            _courseService = courseService;
            _specializationService = specializationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            if (courses == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(courses);
        }

        [HttpGet("parent/{id}")]
        public async Task<IActionResult> GetAllFromParent(int id)
        {
            var courses = await _courseService.GetAllFromParentAsync(id);
            if (courses == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            var specialization = await _specializationService.GetByIdAsync(course.SpecializationId);
            if (specialization == null)
            {
                return NotFound("Specialization not found");
            }
            course.Specialization = specialization;
            var createdCourse = await _courseService.CreateAsync(course);
            return Ok(createdCourse);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Course course)
        {
            var specialization = await _specializationService.GetByIdAsync(course.SpecializationId);
            if (specialization == null)
            {
                return NotFound("Specialization not found");
            }
            course.Specialization = specialization;
            var updatedCourse = await _courseService.UpdateAsync(course);
            return Ok(updatedCourse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            await _courseService.DeleteAsync(id);
            return Ok();
        }

    }
}
