using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _courseSubjectService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _courseSubjectService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseSubject courseSubject)
        {
            try
            {
                return Ok(await _courseSubjectService.CreateAsync(courseSubject));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CourseSubject courseSubject)
        {
            try
            {
                return Ok(await _courseSubjectService.UpdateAsync(courseSubject));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _courseSubjectService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
