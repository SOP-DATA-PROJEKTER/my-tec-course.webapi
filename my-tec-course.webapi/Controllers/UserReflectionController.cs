using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;

namespace my_tec_course.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReflectionController : ControllerBase
    {
        private readonly IUserReflectionService _userReflectionService;

        public UserReflectionController(IUserReflectionService userReflectionService)
        {
            _userReflectionService = userReflectionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserReflection userReflection)
        {
            try
            {
                return Ok(await _userReflectionService.CreateAsync(userReflection));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserReflection()
        {
            try
            {
                return Ok(await _userReflectionService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserReflectionById(int id)
        {
            try
            {
                return Ok(await _userReflectionService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserReflection([FromBody] UserReflection userReflection)
        {
            try
            {
                return Ok(await _userReflectionService.UpdateAsync(userReflection));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserReflection(int id)
        {
            try
            {
                return Ok(await _userReflectionService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
