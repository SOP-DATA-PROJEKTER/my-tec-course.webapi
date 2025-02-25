using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;
using System.Threading.Tasks;

namespace my_tec_course.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilestoneController : ControllerBase
    {
        private readonly IBaseService<Milestone> _milestoneService;
        private readonly IBaseService<Subject> _subjectService;

        public MilestoneController(IBaseService<Milestone> milestoneService, IBaseService<Subject> subjectService)
        {
            _milestoneService = milestoneService;
            _subjectService = subjectService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var milestones = await _milestoneService.GetAllAsync();
            if(milestones == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(milestones);
        }

        [HttpGet("parent/{id}")]
        public async Task<IActionResult> GetAllFromParent(int id)
        {
            var milestones = await _milestoneService.GetAllFromParentAsync(id);
            if (milestones == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(milestones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var milestone = await _milestoneService.GetByIdAsync(id);
            if (milestone == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(milestone);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Milestone milestone)
        {
            var subject = await _subjectService.GetByIdAsync(milestone.SubjectId);
            if (subject == null)
            {
                return BadRequest("Subject not found");
            }

            milestone.Subject = subject;

            var createdMilestone = await _milestoneService.CreateAsync(milestone);
            return Ok(createdMilestone);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Milestone milestone)
        {
            var subject = await _subjectService.GetByIdAsync(milestone.SubjectId);
            if (subject == null)
            {
                return BadRequest("Subject not found");
            }
            milestone.Subject = subject;
            var updatedMilestone = await _milestoneService.UpdateAsync(milestone);
            return Ok(updatedMilestone);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _milestoneService.DeleteAsync(id);
            if (!deleted)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok();
        }


    }
}
