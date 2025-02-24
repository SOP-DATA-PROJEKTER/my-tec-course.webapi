using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IGenericCrudService<Subject> _subjectService;
        private readonly IGenericCrudService<Course> _courseService;

        public SubjectController(IGenericCrudService<Subject> subjectService, IGenericCrudService<Course> courseService)
        {
            _subjectService = subjectService;
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _subjectService.GetAllAsync();
            if (subjects == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var subject = await _subjectService.GetByIdAsync(id);
            if (subject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Subject subject)
        {
            var course = await _courseService.GetByIdAsync(subject.CourseId);
            if (course == null)
            {
                return BadRequest("Course not found");
            }
            subject.Course = course;
            var createdSubject = await _subjectService.CreateAsync(subject);
            return Ok(createdSubject);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Subject subject)
        {
            var course = await _courseService.GetByIdAsync(subject.CourseId);
            if (course == null)
            {
                return BadRequest("Course not found");
            }
            subject.Course = course;
            var updatedSubject = await _subjectService.UpdateAsync(subject);
            return Ok(updatedSubject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _subjectService.DeleteAsync(id);
            if (!result)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok();
        }


    }
}
