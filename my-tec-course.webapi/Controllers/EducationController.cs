using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IGenericCrudService<Education> _educationService;

        public EducationController(IGenericCrudService<Education> educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var educations = await _educationService.GetAllAsync();
            if(educations == null)
            {
                return NotFound();
            }
            return Ok(educations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var education = await _educationService.GetByIdAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            return Ok(education);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Education education)
        {
            var createdEducation = await _educationService.CreateAsync(education);
            if (createdEducation == null)
            {
                return BadRequest();
            }
            return Ok(createdEducation);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Education education)
        {
            var updatedEducation = await _educationService.UpdateAsync(education);
            if (updatedEducation == null)
            {
                return BadRequest();
            }
            return Ok(updatedEducation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _educationService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
