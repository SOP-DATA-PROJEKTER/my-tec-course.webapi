using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _getAllService.GetAllEducationTypes());
        }

        [HttpGet("simple")]
        public async Task<IActionResult> GetAllSimple()
        {
            return Ok(await _educationTypeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _educationTypeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EducationType educationType)
        {
            try
            {
                return Ok(await _educationTypeService.CreateAsync(educationType));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EducationType educationType)
        {
            try
            {

                return Ok(await _educationTypeService.UpdateAsync(educationType));
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
                await _educationTypeService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
