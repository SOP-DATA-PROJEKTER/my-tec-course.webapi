using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathwayController : ControllerBase
    {

        private readonly IBaseService<Pathway> _pathwayService;
        public PathwayController(IBaseService<Pathway> pathwayService)
        {
            _pathwayService = pathwayService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pathways = await _pathwayService.GetAllAsync();
            if(pathways == null)
            {
                return NotFound();
            }
            return Ok(pathways);
        }

        [HttpGet("parent/{id}")]
        public async Task<IActionResult> GetAllFromParent(int id)
        {
            var pathways = await _pathwayService.GetAllFromParentAsync(id);
            if (pathways == null)
            {
                return NotFound();
            }
            return Ok(pathways);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pathway = await _pathwayService.GetByIdAsync(id);
            if (pathway == null)
            {
                return NotFound();
            }
            return Ok(pathway);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pathway pathway)
        {
            var createdPathway = await _pathwayService.CreateAsync(pathway);
            if(createdPathway == null)
            {
                return BadRequest();
            }
            return Ok(createdPathway);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Pathway pathway)
        {
            var updatedPathway = await _pathwayService.UpdateAsync(pathway);
            if (updatedPathway == null)
            {
                return NotFound();
            }
            return Ok(updatedPathway);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pathway = await _pathwayService.GetByIdAsync(id);
            if (pathway == null)
            {
                return NotFound();
            }
            await _pathwayService.DeleteAsync(id);
            return Ok();
        }



    }
}
