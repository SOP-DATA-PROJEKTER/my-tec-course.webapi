using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;


namespace my_tec_course.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {

        private readonly IBaseService<Specialization> _specializationService;
        private readonly IBaseService<Pathway> _pathwayService;

        public SpecializationController(IBaseService<Specialization> specializationService, IBaseService<Pathway> pathwayService)
        {
            _specializationService = specializationService;
            _pathwayService = pathwayService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var specializations = await _specializationService.GetAllAsync();
            if(specializations == null)
            {
                return NotFound();
            }
            return Ok(specializations);
        }

        [HttpGet("parent/{id}")]
        public async Task<IActionResult> GetAllFromParent(int id)
        {
            var specializations = await _specializationService.GetAllFromParentAsync(id);
            if (specializations == null)
            {
                return NotFound();
            }
            return Ok(specializations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var specialization = await _specializationService.GetByIdAsync(id);
            if (specialization == null)
            {
                return NotFound();
            }
            return Ok(specialization);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Specialization specialization)
        {
            var pathway = await _pathwayService.GetByIdAsync(specialization.PathwayId);
            if (pathway == null)
            {
                return NotFound();
            }
            specialization.Pathway = pathway;
            var newSpecialization = _specializationService.CreateAsync(specialization);
            return Ok(newSpecialization);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Specialization specialization)
        {
            var pathway = await _pathwayService.GetByIdAsync(specialization.PathwayId);
            if (pathway == null)
            {
                return NotFound();
            }
            specialization.Pathway = pathway;
            var updatedSpecialization = _specializationService.UpdateAsync(specialization);
            return Ok(updatedSpecialization);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _specializationService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
